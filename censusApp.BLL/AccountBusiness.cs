using censusApp.Shared.Models;
using censusApp.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using censusApp.Shared;

namespace censusApp.BLL
{
    /// <summary>
    /// Class  for handling account related operations
    /// </summary>
    public class AccountBusiness
    {
        public UserDb userDb = new UserDb();

        /// <summary>
        /// Registers a new user account
        /// </summary>
        /// <param name="model">The model passed from the account controller with user data and passed to DAL</param>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            model.Roles = "Volunteer";
            var user = new ApplicationUser()
            {
                Email = model.Email
            };

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ProfilePic = model.ProfilePic;
            user.AadharNumber = model.AadharNumber;
            user.UserName = model.Email;

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            try
            {
                var result = manager.Create(user, model.Password);
                if(result.Succeeded)
                    manager.AddToRole(user.Id, model.Roles);
                return result;
            }
            catch(Exception ex)
            {
                return IdentityResult.Failed(ex.InnerException.InnerException.Message);
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="id">User id </param>
        /// <param name="status">The current status of the user</param>
        public object UpdateStatus(string id,string status)
        {
            return userDb.UpdateUserStatus(id, status);
        }

        /// <summary>
        /// Gets the user list based on status.
        /// </summary>
        /// <param name="currentStatus">The current status.</param>
        /// <returns>List of all the users depending on their status</returns>
        public IEnumerable<VolunteerViewModel> GetUserListBasedOnStatus(string currentStatus)
        {

            var result = userDb.GetUsersBasedOnStatus(currentStatus);
            List<VolunteerViewModel> volunteerList = new List<VolunteerViewModel>();
            foreach(ApplicationUser user in result)
            {
                VolunteerViewModel model = new VolunteerViewModel()
                {
                    UserId = user.Id,
                    Name = user.FirstName + ' ' + user.LastName,
                    ProfilePic = user.ProfilePic,
                    Email = user.Email,
                    Status = user.Status
                };
                volunteerList.Add(model);
            }
            return volunteerList;
        }

        /// <summary>
        /// Gets the user claims.
        /// </summary>
        /// <param name="identityClaims">The identity claims.</param>
        /// <returns>returns claims of the user</returns>
        public AccountModel GetUserClaims(ClaimsIdentity identityClaims)
        {
            
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
                ProfilePic = identityClaims.FindFirst("ProfilePic").Value,
                //AadharNumber = identityClaims.FindFirst("AadharNumber").Value
            };
            model.Status = userDb.GetStatus(model.Email);
            return model;
        }
    }
}
