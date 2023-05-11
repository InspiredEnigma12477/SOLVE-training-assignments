using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VechileMS
{
	public class Car : DealerVehicle
	{
		public  readonly DealerVehicle Ford = new DealerVehicle();
		public Car(string name, string brand, string type, string transmissionType, 
			string color, int launchYear, double price, float discount
			) :base("Car",name,brand,type,transmissionType,color,launchYear, price, discount)
		{
			
		}

        public Car():base()
        {
            this.GetInfo();
        }


    }

}
