using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechileMS.Utils;

namespace VechileMS.Models
{
    public class DealerVehicle : Vehicle
    {
        [Key]
        public int Id { get; set; } // Primary key
        public DateTime SellingMonthAndYear { get; set; }

        [MaxLength(10)]
        public string Number { get; set; }
        public string OwnerDetails { get; set; }

        [MaxLength(255)]
        public string ServicingHistory { get; set; }
        public bool IsAccidental { get; set; } = false;
        public bool IsInServicing { get; set; } = false;

        public List<Note> Notes { get; set; }
        public DateTime ExpiryDate
        {
            get { return SellingMonthAndYear.AddYears(15); }
        }

        public DealerVehicle() { }

        public DealerVehicle(string vechileType)
            : base(vechileType)
        {
            Notes = new List<Note>();
            this.GetDetails();
        }

        public DealerVehicle(
            string vechhileType,
            string name,
            string brand,
            string type,
            string transmissionType,
            string color,
            int launchYear,
            double price,
            float discount
        )
            : base(
                vechhileType,
                name,
                brand,
                type,
                transmissionType,
                color,
                launchYear,
                price,
                discount
            )
        {
            Notes = new List<Note>();
        }

        public override void AddNote(string note)
        {
            Notes.Add(new Note(note));
        }

        public bool InServicing()
        {
            return IsInServicing
                || DateTime.Now >= SellingMonthAndYear && DateTime.Now <= ExpiryDate;
        }

        public override string ToString()
        {
            return $"\nVechile Id              : {Id}"
                + base.ToString()
                + $"\nSelling Month and Year  : {SellingMonthAndYear.ToString("MM/yyyy")}"
                + $"\nNumber                  : {Number}"
                + $"\nOwner Details           : {OwnerDetails} "
                + $"\nExpiry Date             : {ExpiryDate}"
                + $"\nServicing History       : {ServicingHistory}"
                + $"\nIs Accidental           : {IsAccidental}"
                + $"\nIs In Servicing         : {IsInServicing}"
                + $"\nNotes                   : {string.Join(", ", Notes)}";
        }
    }
}
