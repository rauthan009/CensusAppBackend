using censusApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace censusApp.DAL
{
    /// <summary>
    /// Class HouseListingDb.
    /// Implements the <see cref="censusApp.DAL.DALBase" />
    /// </summary>
    public class HouseListingDb: DALBase
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>returns all the house listing in a list</returns>
        public IEnumerable<HouseListing> GetAll()
        {
            return Db.Listings.ToList();
        }

        /// <summary>
        /// Inserts the specified house listing.
        /// </summary>
        /// <param name="house">The house listing</param>
        public void Insert(HouseListing house)
        {
            Db.Listings.Add(house);
            Save();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
