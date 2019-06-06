using censusApp.Shared;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace censusApp.DAL
{
    /// <summary>
    /// Class ApplicationDbContext for creating the DB context to be used throughout the application
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext" />
    /// </summary>
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() :base("censusDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, censusApp.DAL.Migrations.Configuration>());
        }
        public IDbSet<NationalPopulationRegister> NPR { get; set; }
        public IDbSet<HouseListing> Listings { get; set; }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
   
            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            //AspNetRoles -> Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //AspNetUserRoles -> UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
    }
}
