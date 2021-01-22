using System.IO;
using Dao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dao
{
    public class DataContext : DbContext
    {
        #region entity
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ProductTypeModel> ProductTypeModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<BranchModel> BranchModels { get; set; }
        public DbSet<CartModel> CartModels { get; set; }
        

        #endregion

        #region config
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Directory.GetCurrentDirectory() + "/AppData";

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

            var config = builder.Build();
            optionsBuilder.UseSqlServer(config["ConnectionsStrings:ConectSql"]);

        }
        #endregion
    }
}
