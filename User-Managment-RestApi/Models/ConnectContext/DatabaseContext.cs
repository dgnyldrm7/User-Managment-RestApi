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
                .Ignore(x => x._roles)
                .HasOne(x => x._roles)
                .WithMany(x => x._users);

            modelBuilder.Entity<Role>()
                .Ignore(p => p._users)
                .HasKey(x => x.Id);  //Primary key of Role class







            //SEED DATAS!
            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = 1,
                        RoleName = "Admin",
                        Description = "This is admin!",
                        CreatedTime = DateTime.Now,
                    },
                    new Role
                    {
                        Id = 2,
                        RoleName = "Writer",
                        Description = "This is writer!",
                        CreatedTime = DateTime.Now,
                    }
                );

            modelBuilder.Entity<User>().HasData(
                   new User
                   {
                       Id = 1,
                       Name = "Test1",
                       LastName = "Test1",
                       Email = "test1@gmail.com",
                       Password = "123456",
                       ConfirmPassword = "123456",
                       CreatedTime = DateTime.Now,
                       RoleId = 1
                   },
                   new User
                   {
                       Id = 2,
                       Name = "Test2",
                       LastName = "Test2",
                       Email = "test2@gmail.com",
                       Password = "123456*",
                       ConfirmPassword = "123456*",
                       CreatedTime = DateTime.Now,
                       RoleId = 1
                   },
                   new User
                   {
                       Id = 3,
                       Name = "Test3",
                       LastName = "Test3",
                       Email = "test3@gmail.com",
                       Password = "123",
                       ConfirmPassword = "123",
                       CreatedTime = DateTime.Now,
                       RoleId = 2
                   },
                   new User
                   {
                       Id = 4,
                       Name = "Test4",
                       LastName = "Test4",
                       Email = "test4@gmail.com",
                       Password = "12",
                       ConfirmPassword = "12",
                       CreatedTime = DateTime.Now,
                       RoleId = 2
                   }
                );
        }

    }
}
