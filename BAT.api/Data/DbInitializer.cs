using BAT.api.Models.Entities;
using BAT.api.Models.enums;
using BAT.api.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BAT.api.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Permission>().HasData(
                   //base permissions
                   new Permission { Id = 1, Name = "Can use upload data feature",PermissionId = 1, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 2, Name = "Can use the process data feature",PermissionId=2, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 3, Name = "Can use the analyze data feature",PermissionId=3, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 4, Name = "Can use the export data feature",PermissionId =4 , Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 5, Name = "Can use the view or edit data feature",PermissionId=5, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 6, Name = "Can use the update data feature",PermissionId=6, Created = DateTime.UtcNow, CreatedBy = 1 },

                   new Permission { Id = 7, Name = "Can add new team", PermissionId = 7, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 8, Name = "Can add new privilege", PermissionId = 8, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 9, Name = "Can change team name", PermissionId = 9, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 10, Name = "Can view teams", PermissionId = 10, Created = DateTime.UtcNow, CreatedBy = 1 },
                   new Permission { Id = 11, Name = "Can add admin users to teams", PermissionId = 11, Created = DateTime.UtcNow, CreatedBy = 1 }
   
            );

            //seed initial Super Admin
            modelBuilder.Entity<Account>().HasData(
                 //base permissions
                 new Account {
                     Id = 1,
                     Created = DateTime.UtcNow,
                     Email = "batAdmin@gmail.com",
                     FirstName = "Dennis",
                     IsOnline = true,
                     LastName = "Osagiede",
                     Username = "mustang247",
                     LastTimeLoggedIn = DateTime.UtcNow,
                     LoggedOutTime = DateTime.UtcNow,
                     PasswordHash = SecureTextHasher.Hash("Nappyboy@247"),
                     Role = ROLES.SuperAdmin,
                     SecretAnswer = new  EncryptionHelper("xUL5gUkY5Gq%j@VR", "S2rgj6U*ydY+hMWx").AESEncrypt("Nappyboy@247"),
                     VerificationToken = ""
                 }
          );
        }
    }

}
