using QuickLocation.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuickLocation.Models
{
    internal class Vehicles
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string VehicleName { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageFilePath { get; set; }


    }
}
