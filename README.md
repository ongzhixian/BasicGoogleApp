# BasicGoogleApp

A basic .NET Core console application 

```ps1: In C:\src\github.com\ongzhixian\BasicGoogleApp
dotnet new sln -n BasicGoogleApp
dotnet new console -n BasicGoogleApp.ConsoleApp
dotnet sln .\BasicGoogleApp.sln add .\BasicGoogleApp.ConsoleApp\


dotnet add .\BasicGoogleApp.ConsoleApp\ package Microsoft.Extensions.Configuration
dotnet add .\BasicGoogleApp.ConsoleApp\ package Microsoft.Extensions.Configuration.UserSecrets
dotnet add .\BasicGoogleApp.ConsoleApp\ package Microsoft.Extensions.Configuration.Json
dotnet add .\BasicGoogleApp.ConsoleApp\ package Microsoft.Data.Analysis
dotnet add .\BasicGoogleApp.ConsoleApp\ package MathNet.Numerics

dotnet add .\BasicGoogleApp.ConsoleApp\ package NLog

Microsoft.Extensions.Http

dotnet user-secrets --project .\BasicGoogleApp.ConsoleApp\ init
dotnet user-secrets --project .\BasicGoogleApp.ConsoleApp\ set "googleCredentials:basicGoogleApp:clientId" "<api-value>"
dotnet user-secrets --project .\BasicGoogleApp.ConsoleApp\ set "googleCredentials:basicGoogleApp:clientSecret" "<api-value>"

```

# 

localhost:4315

Other ways to extend configuration

```
Microsoft.Extensions.Configuration.CommandLine 
Microsoft.Extensions.Configuration.Binder 
Microsoft.Extensions.Configuration.EnvironmentVariables

```

# Reference

https://developers.google.com/identity/protocols/oauth2/native-app

https://github.com/googlesamples/oauth-apps-for-windows
https://github.com/googlesamples/oauth-apps-for-windows/blob/master/OAuthConsoleApp/OAuthConsoleApp/Program.cs
