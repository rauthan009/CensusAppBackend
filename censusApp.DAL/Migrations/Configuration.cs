namespace censusApp.DAL.Migrations
{
    using censusApp.Shared;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "censusApp.DAL.ApplicationDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(censusApp.DAL.ApplicationDbContext context)
        {
            //Seed initial data only if the user is empty
            if (!context.Users.Any())
            {
                var adminEmail = "approver@admin.com";
                var adminUserName = adminEmail;
                var adminFirst = "Harry";
                var adminLastName = "Weasly";
                var adminAadhar = 889287671232;
                var adminPassword = "Admin@123";
                var adminStatus = "Approved";
                string adminRole = "Approver";


                CreateAdminUser(context, adminEmail, adminUserName, adminFirst, adminLastName, adminPassword, adminAadhar,adminRole, adminStatus);
            }
        }

        private void CreateAdminUser(ApplicationDbContext context, string adminEmail, string adminUserName, string adminFirst,string adminLastName, string adminPassword,double adminAadhar, string adminRole,string adminStatus)
        {
            // Create the "admin" user
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                FirstName = adminFirst,
                Email = adminEmail,
                LastName = adminLastName,
                ProfilePic = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMcOCNyd87CBJ9rNAtaf5zhkUNILHwn_BYPQnOZoZ6ueF4Pab6",
                AadharNumber = adminAadhar,
                Status = adminStatus
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore)
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 8,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = false,
                    RequireUppercase = false,
                }
            };


            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

            // Create the "Approver" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            roleCreateResult = roleManager.Create(new IdentityRole("Volunteer"));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add the "admin" user to "Administrator" role
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
        }
    }

