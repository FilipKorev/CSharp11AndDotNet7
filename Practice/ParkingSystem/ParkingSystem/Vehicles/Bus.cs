using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Vehicles
{
    public class Bus : Vehicle
    {
        public bool Toilet { get; set; }
        public Bus() :base() { }

        public Bus(bool toilet, string model, int productionYear, Person owner, int weight, int width, string fuelType, int passengersNo) : base(model, productionYear, owner, weight, width, fuelType, passengersNo)
        {
            Toilet = toilet;
        }
        public override int isEconomic()
        {
            return base.isEconomic();
        }
    }
}
