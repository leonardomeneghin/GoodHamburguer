using Microsoft.Extensions.Configuration;

public static class ConfigHelper
{
    private static IConfigurationRoot _configuration;

    static ConfigHelper()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json");

        _configuration = builder.Build();
    }

    public static string GetConnectionString(string name)
    {
        return _configuration["SQLServerConnection:SQLServerConnectionString"];

    }
}