using System.ComponentModel.DataAnnotations;

namespace censusApp.Shared.Models
{
    public class HouseViewModel
    {
        [Required]
        public string BuildingNumber { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string OwnershipStatus { get; set; }
        public int NoOfRoom { get; set; }
    }
}
