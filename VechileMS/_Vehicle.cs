using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace VechileMS
{
    public abstract class _Vehicle
    {
        public string Name { get; set; }
        public string Made { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string TransmissionType { get; set; }
        public string Color { get; set; }
        public int LaunchYear { get; set; }
        public DateTime SellingMonthAndYear { get; set; }
        public double Price { get; set; }
        public float Discount { get; set; }

        // Properties which can not be set from outside
        public virtual DateTime ExpiryDate { get { return SellingMonthAndYear.AddYears(15); } }


        public _Vehicle()
        {
        }

        public _Vehicle(string name, string made, string brand, string type,
            string transmissionType, string color, int launchYear, DateTime sellingMonthAndYear,
            double price, float discount, string number, string ownerDetails,
            string servicingHistory, bool isAccidental, bool isInServicing)
        {
            Name = name;
            Made = made;
            Brand = brand;
            Type = type;
            TransmissionType = transmissionType;
            Color = color;
            LaunchYear = launchYear;
            SellingMonthAndYear = sellingMonthAndYear;
            Price = price;
            Discount = discount;
        }

        public override string ToString()
        {
            //string notes = Notes.Count == 0 ? "None" : string.Join(", ", Notes);

            return $"Name: {Name}\n" +
                   $"Made: {Made}\n" +
                   $"Brand: {Brand}\n" +
                   $"Type: {Type}\n" +
                   $"Transmission Type: {TransmissionType}\n" +
                   $"Color: {Color}\n" +
                   $"Launch Year: {LaunchYear}\n" +
                   $"Selling Month And Year: {SellingMonthAndYear}\n" +
                   $"Price: {Price}\n" +
                   $"Discount: {Discount}\n";
                   
                   /*
                   $"Number: {Number}\n" +
                   $"Owner Details: {OwnerDetails}\n" +
                   $"Servicing History: {ServicingHistory}\n" +
                   $"Is Accidental: {IsAccidental}\n" +
                   $"Is In Servicing: {IsInServicing}\n" +
                   $"Expiry Month And Year: {ExpiryDate.ToString("MMMM yyyy")}\n" +
                   $"Notes: {notes}\n";
                   */
        }
    }
}
