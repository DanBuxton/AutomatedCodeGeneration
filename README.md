# Automated Code Generation

[![CI](https://github.com/DanBuxton/AutomatedCodeGeneration/actions/workflows/continuous-integration.yml/badge.svg)](https://github.com/DanBuxton/AutomatedCodeGeneration/actions/workflows/continuous-integration.yml)
[![CodeQL](https://github.com/DanBuxton/AutomatedCodeGeneration/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/DanBuxton/AutomatedCodeGeneration/actions/workflows/codeql-analysis.yml)

<!--**This project was submitted in partial fulfillment of the award of the degree of BSc Software Engineering (Final Year Project)**-->

Turns UML documentation, in the form of SQL, into code and uploads to a given users GitHub.

## Intro
The overall purpose of this project is was to automatically generate code and return it to the user. Initially, it was going to be a desktop application that the user installs. However, after a discussion with my supervisor, it was pointed out that the majority of developers have a GitHub account. 

## How to run

1) From https://autocodegen.danbuxton.co.uk, click the 'GitHub Login' button - this will return the code needed to pass as the `CODE`

1) In the CLI project, execute either:

    - `dotnet run --configuration Release -- -id `database_id`  -lang  `language` -path github::`CODE
    - `dotnet run --configuration Release -- -id `database_id`  -lang  `language`  -path ` full_path

