using censusApp.BLL;
using censusApp.Shared.Models;
using System.Web.Http;

//
namespace censusApp.API.Controllers
{
    /// <summary>
    /// Class CensusController for interacting with the census data
    /// Implements the "System.Web.Http.ApiController" />
    /// </summary>
    public class CensusController : ApiController
    {
        
        public CensusBusiness censusBusiness = new CensusBusiness();

        /// <summary>
        /// Creates a new House Listing
        /// </summary>
        /// <param name="model">The model contains the form data posted by the UI application</param>
        /// <returns>returns an Identity Result which represents the result of an identity operation</returns>
        [Route("api/census/addHouse")]
        [HttpPost]
        [Authorize(Roles = "Volunteer")]
        public IHttpActionResult CreateHouseListing(HouseViewModel model)
        {
            if (ModelState.IsValid) { 
                   censusBusiness.CreateHouseListing(model);
                return Ok("Success");
            }
            else
            {
                return Ok("Error creating House List, Entered missing info");
            }
        }

        /// <summary>
        /// Gets the Census House number from the databases
        /// </summary>
        /// <returns>returns an Identity Result which represents the result of an identity operation.</returns>
        [Route("api/census/getHouse")]
        [HttpGet]
        [Authorize(Roles = "Volunteer")]
        public IHttpActionResult GetHouseData()
        {
            return Ok(censusBusiness.GetAllHouse());
        }

        /// <summary>
        /// Adds a new entry into the National Population registor
        /// </summary>
        /// <param name="model">The model contains the form data posted by the UI application</param>
        /// <returns>returns an Identity Result which represents the result of an identity operation.</returns>
        [Route("api/census/addNPr")]
        [HttpPost]
        [Authorize(Roles = "Volunteer")]
        public IHttpActionResult AddNPR(NPRViewModel model)
        {
            censusBusiness.AddNPR(model);
            return Ok("done");

        }
    }
}
