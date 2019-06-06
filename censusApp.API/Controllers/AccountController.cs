using censusApp.BLL;
using censusApp.Shared.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Http;
using censusApp.Shared;

namespace censusApp.API.Controllers
{
    /// <summary>
    /// Contains all the necessary methods for registeration, login and other account related operations
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// Object for the Account Business class in the Business Logic Layer
        /// </summary>
        AccountBusiness accountBusiness = new AccountBusiness();
        ConstantStrings constants = new ConstantStrings();

        #region account related operations
        /// <summary>
        /// Recieves the Post request and calls the Register method in BLL
        /// </summary>
        /// <param name="model">model is the data posted to the API</param>
        /// <returns>returns an Identity Result which represents the result of an identity operation.</returns>
        [Route("api/user/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            return accountBusiness.Register(model);
        }

        /// <summary>
        /// Gets the user claims.
        /// </summary>
        /// <returns>an account model containing user data</returns>
       [Route("api/GetUserClaims")]
        [HttpGet]
        public AccountModel GetUserClaims()
        {
            var IdentityClaims = (ClaimsIdentity)User.Identity;
            return accountBusiness.GetUserClaims(IdentityClaims);
        }

        /// <summary>
        /// Updates the status 
        /// </summary>
        /// <param name="model">The model is  contains the new status for the user</param>
        /// <returns>IHttpActionResult </returns>
        [HttpPost]
        [Route("api/user/updateStatus")]
        [AllowAnonymous]
        public IHttpActionResult UpdateStatus(VolunteerViewModel model)
        {
            return Ok(accountBusiness.UpdateStatus(model.UserId, model.Status));
        }
        #endregion


        #region Operations for getting user data from  the database
        /// <summary>
        /// Gets all the declined users
        /// </summary>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        [HttpGet]
        [Authorize(Roles = "Approver")]
        [Route("api/GetPendingUsers")]
        public IHttpActionResult GetPendingUsers()
        {
            return Ok(accountBusiness.GetUserListBasedOnStatus(constants.PendingStatus));
        }

        /// <summary>
        /// Gets all the approved users
        /// </summary>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        [HttpGet]
        [Authorize(Roles = "Approver")]
        [Route("api/GetApprovedUsers")]
        public IHttpActionResult GetApprovedUsers()
        {
            return Ok(accountBusiness.GetUserListBasedOnStatus(constants.ApprovedStatus));
        }

        /// <summary>
        /// Gets all the declined users
        /// </summary>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        [HttpGet]
        [Authorize(Roles = "Approver")]
        [Route("api/GetDeclinedUsers")]
        public IHttpActionResult GetDeclinedUsers()
        {
            return Ok(accountBusiness.GetUserListBasedOnStatus(constants.DeclinedStatus));
        }
        #endregion
    }
}