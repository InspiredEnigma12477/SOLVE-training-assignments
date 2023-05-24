using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileMS.Models
{
	public abstract class Vehicle
	{
		private static int count = 0;

		[Key]
		public int Id;

		[Required]
		[StringLength(50)]
		public string Model { get; set; }

		[Required]
		[StringLength(50)]
		public string Brand { get; set; }

		[Required]
		[StringLength(50)]
		public string Type { get; set; }

		[Required]
		[StringLength(50)]
		public string TransmissionType { get; set; }

		[Required]
		public int LaunchYear { get; set; }

		[Required]
		[StringLength(50)]
		public string VechileType { get; protected set; }

		[StringLength(50)]
		public string Color { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public double Price { get; set; }

		[Range(0, 100)]
		public float Discount { get; set; }

		public abstract void AddNote(string note);

		public Vehicle() { }

		public Vehicle(string vehicleType)
		{
			Id = ++count;
			VechileType = vehicleType;
		}

		public Vehicle(
			string vechileType,
			string model,
			string brand,
			string type,
			string transmissionType,
			string color,
			int launchYear,
			double price,
			float discount
		)
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

			//return $"{VechileType}\t|{Brand}   \t|{Model}   \t|{Type}\t|{TransmissionType}    \t|{LaunchYear}\t|{Color}\t|{Price}\t|{Discount}";
			
			return $"\nVechileType			   : {VechileType}"
				+ $"\nBrand                   : {Brand}"
				+ $"\nModel                   : {Model}"
				+ $"\nType                    : {Type}"
				+ $"\nTransmission Type       : {TransmissionType}"
				+ $"\nColor                   : {Color}"
				+ $"\nLaunch Year             : {LaunchYear}"
				+ $"\nPrice                   : {Price}"
				+ $"\nDiscount                : {Discount}";
		}
	}
}
