using System;

namespace censusApp.Shared.Models
{
    public class NPRViewModel
    {
        public string FullName { get; set; }
        public string RelationtoHead { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMarried { get; set; }
        public int AgeAtMarriage { get; set; }
        public string OccupationStatus { get; set; }
        public string NatureOfOccupation { get; set; }
    }
}