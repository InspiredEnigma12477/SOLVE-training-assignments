using Microsoft.EntityFrameworkCore;
using VechileMS.DataAcessLogic;
using VechileMS.Models;
using VechileMS.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VechileMS.Utils
{
	public class Helper
	{
		public static int GetMenu()
		{
			int choice = 0;
			Console.WriteLine("\n######### Vehicle Management System #########");
			Console.WriteLine("1. Add Vehicle");
			Console.WriteLine("2. Display All Vehicle");
			Console.WriteLine("3. Filters");
			Console.WriteLine("4. Update Vehicle");
			Console.WriteLine("5. Delete Vehicle");
			Console.WriteLine("99. Exit");
			Console.WriteLine("Enter your choice");
			try
			{
				choice = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException ee)
			{
				Console.WriteLine("Only number allowed!!!! ");
				Console.WriteLine("Please Enter your choice again: ");
				choice = Convert.ToInt32(Console.ReadLine());
			}
			return choice;
		}

		public static void AddVechile(List<Vehicle> list)
		{
			VechileContext _vehicleContext = new VechileContext();

			Console.WriteLine("Enter the Vechile Type");
			//Lower case accept


			switch (Console.ReadLine().ToLower())
			{
				case "car":
					_vehicleContext.Add(new Car());
					break;
				case "truck":
					_vehicleContext.Add(new Truck());
					break;
				case "bus":
					_vehicleContext.Add(new Bus());
					break;
				default:
					Console.WriteLine("Supported Vechile Type (Car, Bus, Truck) : ");
					break;
			}
			_vehicleContext.SaveChanges();
		}

		public static void DeleteVechile() { 
			VechileContext _vehicleContext = new VechileContext();
			Console.WriteLine("Enter the Vechile Id");
			int id = Convert.ToInt32(Console.ReadLine());
            _vehicleContext.Note.Remove(_vehicleContext.Note.Find(id));
            _vehicleContext.Vehicles.Remove(_vehicleContext.Vehicles.Find(id));
            _vehicleContext.SaveChanges();
		}

		public static void SearchVechile()
		{
			VechileContext _vehicleContext = new VechileContext();
			Console.WriteLine("Enter the Vechile Type");
		}

		public static void DisplayVechile()
		{
			VechileContext _vehicleContext = new VechileContext();
			List<DealerVehicle> list = _vehicleContext.Vehicles.Include(v => v.Notes).ToList();
			//Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
			//Console.WriteLine("|Id\t| VType\t| Brand  \t| Model   \t| FType\t| TransType \t| LYear\t| Color\t| Price\t| Discount\t| SDate  \t| Number\t| Owner Details\t| Expiry Date\t| Servicing \t| IsAccidental\t| IsInServicing\t| Notes \t\t\t|");
			//Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

			//Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");



			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
			//Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");	
		}

		internal static void Exit()
		{
			throw new NotImplementedException();
		}


		internal static void ModifyServicingStatus()
		{
			throw new NotImplementedException();
		}
		public static void Filters()
		{
            VechileContext _vehicleContext = new VechileContext();
            int choice = 0;
			Console.WriteLine("\n Filters. ");
			Console.WriteLine("1. Brand. ");
			Console.WriteLine("2. Color. ");
			Console.WriteLine("3. Number. ");
			Console.WriteLine("4. Accidental Status. ");
			Console.WriteLine("Enter your choice");
			try
			{
				choice = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException ee)
			{
				Console.WriteLine("Only number allowed!!!! ");
				Console.WriteLine("Please Enter your choice again: ");
				choice = Convert.ToInt32(Console.ReadLine());
			}

			switch(choice)
			{
				case 1:
					
						Console.WriteLine("Enter the Brand");
						List<DealerVehicle> list = new CarSeller(_vehicleContext.Vehicles.Include(v => v.Notes).ToList()).GetVehiclesByBrand(Extensions.GetBrand());
						foreach (var item in list)
						{
							Console.WriteLine(item);
						}

					
					break;
				case 2:
					Console.WriteLine("Enter the Color");
                    List<DealerVehicle> list1 = new CarSeller(_vehicleContext.Vehicles.Include(v => v.Notes).ToList()).GetVehiclesByColor(Extensions.GetColour());
                    foreach (var item in list1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
				case 3:
					Console.WriteLine("Enter the Number");
					break;
				case 4:
					Console.WriteLine("Enter the Accidental Status");
					break;
				default:
					Console.WriteLine("Please Enter your choice again: ");
					break;
			}
		}
	}
}
