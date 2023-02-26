using QuickLocation.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLocation.Data
{
    internal class VehiclesDataBase
    {
        static SQLiteAsyncConnection Database;
    
    
        public static readonly AsyncVehicles<VehiclesDataBase> Instance =
            new AsyncVehicles<VehiclesDataBase>(async () =>
            {
                var instance = new VehiclesDataBase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<Vehicles>();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return instance;
            });

        public VehiclesDataBase()
        {
            Database = new SQLiteAsyncConnection(constants.DatabasePath, constants.Flags);
        }

        public Task<List<Vehicles>> GetItemsAsync()
        {
            return Database.Table<Vehicles>().ToListAsync();
        }

        public Task<List<Vehicles>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Vehicles>("SELECT * FROM [Vehicles] WHERE [Done] = 0");
        }

        public Task<Vehicles> GetItemAsync(int id)
        {
            return Database.Table<Vehicles>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Vehicles item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Vehicles item)
        {
            return Database.DeleteAsync(item);
        }


    }

}
