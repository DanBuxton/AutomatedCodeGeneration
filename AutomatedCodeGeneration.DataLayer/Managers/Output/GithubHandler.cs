using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using Octokit;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output;

public sealed class GithubHandler : IOutputHandler
{
    private readonly string _systemId;
    public string OutputDetails { get; }

    public GithubHandler(string code, string systemId)
    {
        _systemId = systemId;
        OutputDetails = code;
    }
    
    private static async Task<GitHubClient> GetGithubClient(string code)
    {
        //Potentially need user consent to generate the required code.

        //TODO: Store in some form of secret
        const string appClientId = "97ce255accacf4d16e86", appClientSecret = "e8fb5ce22f33011c957ea335897fbf7b741405b2";

        var client = new GitHubClient(new ProductHeaderValue("AutomatedCodeGeneration"));

        var result = await client.Oauth.CreateAccessToken(new OauthTokenRequest(appClientId, appClientSecret, code));
        
        client.Credentials = new Credentials(result.AccessToken, AuthenticationType.Bearer);
        
        return client;
    }

    public async Task<bool> Output(IList<IFileModel> files, CancellationToken token)
    {
        var client = await GetGithubClient(OutputDetails);

        var user = await client.User.Current();

        switch (user.Type)
        {
            case AccountType.Organization:
            case AccountType.User:
                var clientRepo = client.Repository;

                var repo = await clientRepo.Create(new NewRepository($"AutoCodeGeneration_{_systemId}_{files.First().FileExt}")
                {
                    Private = true,
                    Homepage = "https://autocodegen.danbuxton.co.uk",
                    Description = "Created using AutomatedCodeGeneration",
                    HasDownloads = false,
                    HasIssues = false,
                    HasWiki = false
                });
                
                var author = new Committer("Automated Code Generator", "autocodegen@danbuxton.co.uk", new DateTimeOffset(new DateTime(2021, 5, 25, 23, 59, 59)));
                
                await Task.Run(async () =>
                {


                    foreach (var file in files)
                    {
                        await clientRepo.Content.CreateFile(repo.Id, $"{file.FileName}.{file.FileExt}", new CreateFileRequest($"Generated {file.FileName}", file.Generate().ToString()) { Author = author });
                    }
                },token);

                return true;
            case AccountType.Bot:
                throw new IOException("Account type not supported");
            default: return false;
        }
    }
}