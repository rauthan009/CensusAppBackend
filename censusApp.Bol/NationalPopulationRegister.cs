using System;
using System.ComponentModel.DataAnnotations;

namespace censusApp.Shared
{
    public partial class NationalPopulationRegister
    {
        [Key]
        public int NPRId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RelationtoHead { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool IsMarried { get; set; }
        public int AgeAtMarriage { get; set; }
        public string OccupationStatus { get; set; }
        public string NatureOfOccupation { get; set; }
    }
}
