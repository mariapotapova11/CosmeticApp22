using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CosmeticApp.Model;
using System.Runtime.Remoting.Contexts;

namespace CosmeticApp.DataAccessLayer
{
    /// <summary>
    /// Контекст базы данных Entity Framework
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CosmeticDb;Integrated Security=True;") { }

        public DbSet<Cosmetic> Cosmetics { get; set; }
    }
}
