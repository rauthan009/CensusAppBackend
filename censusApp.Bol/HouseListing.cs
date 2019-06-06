using System.ComponentModel.DataAnnotations;

namespace censusApp.Shared
{
    public partial class HouseListing
    {
        [Key]
        public int HouseId { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string FullNameofHead { get; set; }
        [Required]
        public bool IsOwned { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public string CensusHouseNumber { get; set; }
    }
}
