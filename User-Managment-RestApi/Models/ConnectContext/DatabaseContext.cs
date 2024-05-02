using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.ConnectContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //controller is here!
        }


        //Define Entity Classes!
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }




        //Settings Configuring!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defined Here(RelationShips) with fluent api!
            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Users);

            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);  //Primary key of Role class





            // Seed data ekleme
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    Description = "Admin role",
                    CreatedTime = DateTime.Now
                },
                new Role
                {
                    Id = 2,
                    RoleName = "User",
                    Description = "Regular user role",
                    CreatedTime = DateTime.Now
                }
            );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    Password = "password123",
                    ConfirmPassword = "password123",
                    CreatedTime = DateTime.Now,
                    RoleId = 1 // Admin rolü
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    LastName = "Doe",
                    Email = "jane@example.com",
                    Password = "password456",
                    ConfirmPassword = "password456",
                    CreatedTime = DateTime.Now,
                    RoleId = 2 // User rolü
                }
        );






        }

    }
}
