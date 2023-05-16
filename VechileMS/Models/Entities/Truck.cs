using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VechileMS.Models;
using VechileMS.Utils;

namespace VechileMS.Models.Entities
{
    public class Truck : DealerVehicle
    {
        public Truck(string name, string brand, string type, string transmissionType,
            string color, int launchYear, double price, float discount
            ) : base("Truck", name, brand, type, transmissionType, color, launchYear, price, discount)
        {

        }

        public Truck() : base("Truck")
        {
            this.GetInfo();
        }

        public override void AddNote(string note)
        {
            base.AddNote(note);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}
