using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace censusApp.Shared
{
    /// <summary>
    /// This class inherits from microsoft identity to create a class for storing a user details
    /// </summary>
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser() => Status = "Pending";
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ProfilePic { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public double AadharNumber { get; set; }
        public string Status { get; set; }
    }
}
