using censusApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace censusApp.DAL
{
    /// <summary>
    /// Class UserDb to interact directly with the user in database
    /// Implements the <see cref="censusApp.DAL.DALBase" />
    /// </summary>
    public class UserDb : DALBase
    {
        /// <summary>
        /// Gets the users based on status.
        /// </summary>
        /// <param name="currStatus">The current status.</param>
        /// <returns>Returns a list of users based their current status</returns>
        public IEnumerable<ApplicationUser> GetUsersBasedOnStatus(string currStatus)
        {
            var usersList = Db.Users.Where(e => e.Status.Equals(currStatus));
            return usersList.ToList();
        }

        /// <summary>
        /// Updates the user status.
        /// </summary>
        /// <param name="Id">The id of the user.</param>
        /// <param name="status">The status.</param>
        /// <returns>System.Object.</returns>
        public object UpdateUserStatus(string Id,string status)
        {
            ApplicationUser userToUpdate = Db.Users.Find(Id);
            userToUpdate.Status = status;
            try
            { 
                Db.SaveChanges();
                return "success";
            }
            catch(Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns the status of a user as a string</returns>
        public string GetStatus(string email)
        {
            ApplicationUser user = Db.Users.Where(e => e.Email == email).FirstOrDefault();
            return user.Status;
        }
    }
}
