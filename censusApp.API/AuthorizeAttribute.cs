using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace censusApp.API
{
    /// <summary>
    /// Class AuthorizeAttributes
    /// Implements the <see cref="System.Web.Http.AuthorizeAttribute" />
    /// </summary>
    /// <seealso cref="System.Web.Http.AuthorizeAttribute" />
    public class AuthorizeAttributes:AuthorizeAttribute
    {
        /// <summary>
        /// Processes requests that fail authorization.
        /// </summary>
        /// <param name="actionContext">The context encapsulates all HTTP-specific information about an individual HTTP request. </param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if(!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}