using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace GoodHamburguerAPI.Helper
{
    public class SerilogConfigurationHelper
    {
        public static string GOOD_HAMBURGUER_TABLE_LOG = "[Logs_API]";
        public MSSqlServerSinkOptions BuildSinkOptions(string tableName)
        {
            return new MSSqlServerSinkOptions()
            {
                TableName = tableName,
            };
        }

    }
}
