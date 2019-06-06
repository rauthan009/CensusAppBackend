using System.Collections.Generic;
using censusApp.Shared.Models;
using censusApp.Shared;
using censusApp.DAL;
using System;

namespace censusApp.BLL
{
    /// <summary>
    /// Class for census business operations
    /// </summary>
    public class CensusBusiness
    {
        public HouseListingDb listingDb = new HouseListingDb();
        public NPRDb nprDb = new NPRDb();

        /// <summary>
        /// Creates the house listing.
        /// </summary>
        /// <param name="model">The model containing House Listing data</param>
        public void CreateHouseListing(HouseViewModel model)
        {
            HouseListing house = new HouseListing()
            {
                BuildingNumber = model.BuildingNumber,
                Address = model.Address,
                State = model.State,
                FullNameofHead = model.Name,
                NumberOfRooms = model.NoOfRoom,
                IsOwned = (model.OwnershipStatus == "Owned") ? true : false,
                CensusHouseNumber = model.Name.Substring(0,(model.Name.Length/2)) + "-" +  Guid.NewGuid()
                
            }; 
            listingDb.Insert(house);

        }

        /// <summary>
        /// Gets all house.
        /// </summary>
        /// <returns>List of all the census house numbers</returns>
        public List<string> GetAllHouse()
        {
            var result =  listingDb.GetAll();
            List<string> censusNumberList= new List<string>();
            foreach(HouseListing house in result)
            {
                censusNumberList.Add(house.CensusHouseNumber);
            }
            return censusNumberList;
        }

        /// <summary>
        /// Adds the NPR.
        /// </summary>
        /// <param name="model">The model containing National Population Registeration data </param>
        public void AddNPR(NPRViewModel model)
        {
            NationalPopulationRegister npr = new NationalPopulationRegister()
            {
                AgeAtMarriage = model.AgeAtMarriage,
                DateOfBirth =model.DateOfBirth,
                FullName = model.FullName,
                Gender = model.Gender,
                IsMarried = model.IsMarried,
                NatureOfOccupation=model.NatureOfOccupation,
                OccupationStatus = model.OccupationStatus,
                RelationtoHead = model.RelationtoHead
            };
             nprDb.Insert(npr);
        }
    }
}
