using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS
{
    public class Vehicle : _Vehicle
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


        public virtual string BrandOverride { get; set; }
        public virtual string Number { get; set; }
        public virtual string OwnerDetails { get; set; }
        public virtual string ServicingHistory { get; set; }
        public virtual bool IsAccidental { get; set; } = false;
        public virtual bool IsInServicing { get; set; } = false;
        public virtual List<string> Notes { get; set; }
                
        // Properties which can not be set from outside
        public virtual DateTime ExpiryDate { get { return SellingMonthAndYear.AddYears(15); } }


        public Vehicle()
        {
            Notes = new List<string>();
        }
        public void AddNote(string note)
        {
            Notes.Add(note);
        }
        public bool InServicing()
        {
            return IsInServicing || (DateTime.Now >= SellingMonthAndYear && DateTime.Now <= ExpiryDate);
        }
        public void Cal()
        {

        }

        public Vehicle(string name, string made, string brand, string type,
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
            Number = number;
            OwnerDetails = ownerDetails;
            ServicingHistory = servicingHistory;
            IsAccidental = isAccidental;
            IsInServicing = isInServicing;
            Notes = new List<string>();
        }

        public override string ToString()
        {
            string notes = Notes.Count == 0 ? "None" : string.Join(", ", Notes);

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
        }
    }

}
