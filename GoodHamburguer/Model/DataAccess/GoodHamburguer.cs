using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerAPI.Model.DataAccess
{
    public class GoodHamburguer : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Enhance: can use Environment to get connection string from a good and safe place. It will keep like this for now.
            optionsBuilder.UseSqlServer("Data Source=.\\DEVELOPMENT; Database=GOOD_HAMBURGUER; Integrated Security=SSPI; TrustServerCertificate=true;");
        }
    }
}
