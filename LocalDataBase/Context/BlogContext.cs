using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace LocalDataBase.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DataInformation> DataInformation { get; set; }

        public BlogContext()
        {
            SQLitePCL.Batteries_V2.Init();
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string dbFile = Path.Combine(basePath, "blog.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbFile}");
        }
    }
}
