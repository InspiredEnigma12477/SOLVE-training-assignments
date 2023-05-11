using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS
{
    public abstract class Vehicle
    { 
        [Key]
        public int Id { get; protected set; }

        [Required]
        [StringLength(50)]
        public string Model { get; protected set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; protected set; }

        [Required]
        [StringLength(50)]
        public string Type { get; protected set; }

        [Required]
        [StringLength(50)]
        public string TransmissionType { get; protected set; }

        [Required]
        public int LaunchYear { get; protected set; }

        [Required]
        [StringLength(50)]
        public string VechileType { get; protected set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }

        [Range(0, 100)]
        public float Discount { get; set; }

        [NotMapped]
        public string Note { get; set; }

        public abstract void AddNote(string note);

        public Vehicle()
        {

        }
        public Vehicle(string vechileType, string model, string brand, string type, string transmissionType, string color, int launchYear, double price, float discount)
        {
            VechileType = vechileType;
            Model = model;
            Brand = brand;
            Type = type;
            TransmissionType = transmissionType;
            Color = color;
            LaunchYear = launchYear;
        }


        public override string ToString()
        {
            return $"Model: {Model}\n" +
                   $"Brand: {Brand}\n" +
                   $"Type: {Type}\n" +
                   $"Transmission Type: {TransmissionType}\n" +
                   $"Color: {Color}\n" +
                   $"Launch Year: {LaunchYear}\n" +
                   $"Price: {Price}\n" +
                   $"Discount: {Discount}\n";
        }
    }

}
