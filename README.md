# kuref-service

![.NET Core](https://github.com/dcidallendes/kuref-service/workflows/.NET%20Core/badge.svg?branch=master)

A REST service for weather station measurement posting, developed using ASP.Net Core 3.1 Framework. Additionally, contains the measurements database definition employing Entity Framework Core.

This repository is part of the [Kuref](https://github.com/dcidallendes/kuref) Framework.

## Getting started 🚀

This repository contains a Visual Studio Solution (.sln) with a project called Kuref.Service wich is a ASP.Net Core application that implements a REST API for measurements posting to a database.

### Prerequisites 📋

.NET Core SDK 3.1 is required in order to run the application locally. This SDK can be directly downloaded from the [Microsoft](https://dotnet.microsoft.com/download) site. 

Visual Studio 2019 or Visual Studio Code may be used for development.

A Postgres 11 database is required in order to post measurements. 

Entity Framework Tools must be installed. It can be installed using the following command:

```
dotnet tool install --global dotnet-ef
```

### Installing 🔧

Once cloned, a proper connection string should be configured within `appsettings.Development.json` file. To do so, fill `KurefContext` property with the connection string pointing to your previously created Postgres database.

Then, using the command line, site on the Kuref.Service project folder and run the following command that apply migrations to your database:

```
dotnet ef database update
```

Now you are ready to run your local enviroment. If everything went well, a Swagger page could be seen under https://localhost:5001/swagger/index.html url.


## Deploying 📦

TBD

## Contributing 🖇️

TBD


## Versioning 🖇️

[SemVer](https://semver.org/) will be used to name different versions of this component. For the versions available, see the [releases](https://github.com/dcidallendes/kuref-service/releases) on this repository

## Documentation 📖

Kuref project can be found [here](https://github.com/dcidallendes/kuref)
