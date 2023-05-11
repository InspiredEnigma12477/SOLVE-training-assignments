using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VechileMS
{
    public class Truck : DealerVehicle
    {
        public Truck(string name, string brand, string type, string transmissionType,
            string color, int launchYear, double price, float discount
        ) : base("Car", name, brand, type, transmissionType, color, launchYear, price, discount)
        {
            this.GetInfo();
        }
    }
}
