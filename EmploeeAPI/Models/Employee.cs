namespace EmploeeAPI.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }
		public string City { get; set; }
		public double Salary { get; set; }

		public Employee(int id, string name, string department, string city, double salary)
		{
			Id = id;
			Name = name;
			Department = department;
			City = city;
			Salary = salary;
		}

		public Employee()
		{
		}
	}
}
