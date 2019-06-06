using censusApp.BLL;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace censusApp.API.Controllers
{
    /// <summary>
    /// Class RoleController contains the method for getting user role
    /// Implements the System.Web.Http.ApiController"/>
    /// </summary>
    public class RoleController : ApiController
    {

        RoleBusiness rolesBusiness = new RoleBusiness();

        /// <summary>
        /// Gets the roles of the users from  the database
        /// </summary>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roles = rolesBusiness.GetRoles();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
    }
}