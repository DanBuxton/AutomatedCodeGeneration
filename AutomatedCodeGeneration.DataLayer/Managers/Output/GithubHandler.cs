using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using Octokit;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output
{
    public sealed class GithubHandler : IOutputHandler
    {
        public string OutputDetails { get; set; }

        public GithubHandler(string outputDetails)
        {
            OutputDetails = outputDetails;
        }
        
        private static IGitHubClient GetGithubClient(string token)
        {
            //const string appClientId = "97ce255accacf4d16e86";//, appClientSecret = "e8fb5ce22f33011c957ea335897fbf7b741405b2";
            var client = new GitHubClient(new ProductHeaderValue("Automated Code Generation"));
            var tokenAuth = new Credentials(token, AuthenticationType.Bearer);
            client.Credentials = tokenAuth;

            return client;
        }

        public async Task<bool> Output(IList<IFileModel> files, CancellationToken token)
        {
            const string appClientId = "97ce255accacf4d16e86";//, appClientSecret = "e8fb5ce22f33011c957ea335897fbf7b741405b2";

            var client = GetGithubClient(OutputDetails);

#if DEBUG
            Debug.WriteLine($"Scopes: {string.Join(", ", (await client.Authorization.CheckApplicationAuthentication(appClientId, OutputDetails)).Scopes)}");
#endif

            var user = await client.User.Current();

            if (!user.Type.HasValue) return false;


            switch (user.Type.Value)
            {
                case AccountType.Organization:
                case AccountType.User:
                    var clientRepo = client.Repository;

                    //TODO: Use systemId in repository name
                    var repo = await clientRepo.Create(new NewRepository("name")
                    {
                        HasDownloads = false,
                        HasIssues = false,
                        HasWiki = false,
                        Visibility = RepositoryVisibility.Private
                    });

                    var author = new Committer("Automated-Code-Generation", "dan.buxton99@gmail.com", new DateTimeOffset(new DateTime(2021, 5, 11, new GregorianCalendar())));

                    var createFile = await clientRepo.Content.CreateFile(repo.Id, "/", new CreateFileRequest("", "") { Author = author });



                    return true;
                default: return false;
            }
        }
    }
}