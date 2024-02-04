using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext()
        {

        }
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {

        }
        
    }
}
