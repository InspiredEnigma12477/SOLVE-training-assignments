namespace VechileMS
{
	public class Helper
	{
		public static int GetMenu()
		{
			int choice = 0;
			do
			{
				Console.WriteLine("1. Add Vehicle");
				Console.WriteLine("2. Display Vehicle");
				Console.WriteLine("3. Search Vehicle");
				Console.WriteLine("4. Update Vehicle");
				Console.WriteLine("5. Delete Vehicle");
				Console.WriteLine("6. Exit");
				Console.WriteLine("Enter your choice");
				choice = Convert.ToInt32(Console.ReadLine());
			} while (choice <= 0 || choice > 6);
			return choice;
		}

		public static void AddVechile()
		{
			Vehicle car = new Car();
			
		}

		public static void RemoveVechile()
		{
			
		}

		public static void SearchVechile()
		{
			
		}

        internal static void DisplayVechile()
        {
            throw new NotImplementedException();
        }

        internal static void Exit()
        {
            throw new NotImplementedException();
        }
    }
}