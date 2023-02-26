

namespace QuickLocation
{
    public static class constants
    {
        public const string DatabaseFilename = "VehiclesSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath 
        {



            get 
            {
                var basepath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basepath, DatabaseFilename);
            }
            
        } 

    }

}
