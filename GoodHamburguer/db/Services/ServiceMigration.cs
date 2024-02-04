using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace GoodHamburguerAPI.db.Services
{
    public static class ServiceMigration
    {
        public static void MigrateDataBase(string connection)
        {
            try
            {
                var evolveConnection = new SqlConnection(connection);
                var evolve = new Evolve(evolveConnection)
                {
                    Locations = new List<string>() { "db/migrations", "db/datasets" },
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
