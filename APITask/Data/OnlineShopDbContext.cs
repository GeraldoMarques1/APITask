using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using APITask.Models;

namespace APITask.Data
{
	public class OnlineShopDbContext : DbContext
	{
		public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
		: base(options)
		{
			var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
			if (dbCreater != null)
			{
				// Create Database 
				if (!dbCreater.CanConnect())
				{
					dbCreater.Create();
				}

				// Create Tables
				if (!dbCreater.HasTables())
				{
					dbCreater.CreateTables();
				}
			}
		}

		public DbSet<BlogPost> BlogPosts{ get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
        }
	}
}