using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechileMS.Utils;

namespace VechileMS.Models
{
    public class DealerVehicle : Vehicle
    {
        public DateTime SellingMonthAndYear { get; set; }
        public string Number { get; set; }
        public string OwnerDetails { get; set; }
        public string ServicingHistory { get; set; }
        public bool IsAccidental { get; set; } = false;
        public bool IsInServicing { get; set; } = false;
        public virtual List<string> Notes { get; set; }
        public DateTime ExpiryDate { get { return SellingMonthAndYear.AddYears(15); } }

        public DealerVehicle() : base("Car")
        {
            Notes = new List<string>();
            this.GetDetails();
        }
        public DealerVehicle(string vechhileType, string name, string brand, string type,
            string transmissionType, string color, int launchYear, double price, float discount
            ) : base(vechhileType, name, brand, type, transmissionType, color, launchYear, price, discount)
        {
            Notes = new List<string>();
        }
        public override void AddNote(string note)
        {
            Notes.Add(note);
        }
        public bool InServicing()
        {
            return IsInServicing || DateTime.Now >= SellingMonthAndYear && DateTime.Now <= ExpiryDate;
        }
        public override string ToString()
        {
            return base.ToString() +
                $"\nSelling Month and Year: {SellingMonthAndYear.ToString("MM/yyyy")}" +
                $"\nNumber: {Number}" +
                $"\nOwner Details: {OwnerDetails} " +
                $"\nExpiry Date : {ExpiryDate}" +
                $"\nServicing History: {ServicingHistory}" +
                $"\nIs Accidental: {IsAccidental}" +
                $"\nIs In Servicing: {IsInServicing}" +
                $"\nNotes: {string.Join(", ", Notes)}";
        }
    }
}
