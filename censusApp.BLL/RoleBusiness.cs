using censusApp.Shared;
using censusApp.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace censusApp.BLL
{
    /// <summary>
    /// Class for role business operations
    /// </summary>
    public class RoleBusiness
    {
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>Returns all the roles</returns>
        public object GetRoles()
        {
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            RoleManager<IdentityRole> roleMngr = new RoleManager<IdentityRole>(roleStore);

            object roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return roles;           
        }
    }
}
