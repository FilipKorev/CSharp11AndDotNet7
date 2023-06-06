using ParkingSystem.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.ParkingSys
{
    public class VehicleInfo
    {
        public Vehicle Vehicle { get; set; }
        public int MyProperty { get; set; }
        public bool IsCar { get; set; }
        public bool IsLorry { get; set; }
        public bool IsBus { get; set; }
        public VehicleInfo() { }

        public VehicleInfo(Vehicle vehicle, int myProperty, bool isCar, bool isLorry, bool isBus)
        {
            Vehicle = vehicle;
            MyProperty = myProperty;
            IsCar = isCar;
            IsLorry = isLorry;
            IsBus = isBus;
        }
    }
}
