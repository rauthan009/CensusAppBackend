using censusApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace censusApp.DAL
{
    /// <summary>
    /// Class NPRDb.
    /// Implements the <see cref="censusApp.DAL.DALBase" />
    /// </summary>
    public class NPRDb: DALBase
    {
        /// <summary>
        /// Gets all NPR data
        /// </summary>
        /// <returns>Returns all national population data as a list</returns>
        public IEnumerable<NationalPopulationRegister> GetAll()
        {
            return Db.NPR.ToList();
        }

        /// <summary>
        /// Inserts the specified NPR.
        /// </summary>
        /// <param name="npr">The NPR data from the DAL</param>
        public void Insert(NationalPopulationRegister npr)
        {
            Db.NPR.Add(npr);
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
