
namespace VechileMS
{
	public class Setup
	{
		public Setup()
		{
			Console.WriteLine("#######################################################");
			Console.WriteLine("################# Vechile Management ##################");
			Console.WriteLine("#######################################################");
			
			//Helper.LoadData();

			Vehicle car = new Car();

			car.
			
			
			do
			{
				switch(Helper.GetMenu())
				{
					case 1:
						Helper.AddVechile();
						break;
					case 2:
						Helper.RemoveVechile();
						break;
					case 3:
						Helper.SearchVechile();
						break;
					case 4:
						Helper.DisplayVechile();
						break;
					case 5:
						Helper.Exit();
						break;
					default:
						Console.WriteLine("Invalid Choice");
						break;
				}

			}while(true);
			
			Console.ReadKey();
		}
	}
}

