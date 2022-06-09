using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BasicGoogleApp.ConsoleApp;

internal class AppState
{
    const string APP_SETTINGS_CONFIGURATION_FILE = "appsettings.json";
    const string APP_SETTINGS_DEVELOPMENT_CONFIGURATION_FILE = "appsettings.Development.json";

    const string BASIC_GOOGLE_APP_CLIENT_ID_CONFIGURATION_KEY = "googleCredentials:basicGoogleApp:clientId";
    const string BASIC_GOOGLE_APP_CLIENT_SECRET_CONFIGURATION_KEY = "googleCredentials:basicGoogleApp:clientSecret";

    public static IConfiguration Configuration
    {
        get => configuration ?? throw new NullReferenceException();
    }

    internal static void Initialize()
    {
        //var x = configuration.GetRequiredSection("azureApps:basicGraphApp").Get<AzureAppRegistrationSetting>();
    }

    private static readonly IConfiguration? configuration = new ConfigurationBuilder()
        .AddJsonFile(APP_SETTINGS_CONFIGURATION_FILE, optional: false, reloadOnChange: true)
        .AddJsonFile(APP_SETTINGS_DEVELOPMENT_CONFIGURATION_FILE, optional: true)
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
        .Build();

}
