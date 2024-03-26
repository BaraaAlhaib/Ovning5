using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int NumberOfWheels { get; set; } = int.MaxValue;

        public VehicleTypes? VehicleType { get; set; }
    }
    public enum VehicleTypes
    {
        Airplane,     
        Motorcycle,   
        Car,         
        Bus,       
        Boat,       
    }
}
