namespace censusApp.DAL
{
    /// <summary>
    /// Class Base class for all the DAL classes
    /// </summary>
    public class DALBase
    {
        protected ApplicationDbContext Db;

        public DALBase()
        {
            Db = new ApplicationDbContext();
        }
    }
}
