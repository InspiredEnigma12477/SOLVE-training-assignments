using System.ComponentModel.DataAnnotations;

namespace VechileMS.Models
{
	public class Note
	{
		[Key]
		public int Id { get; set; }
		public string note{ get; set; }

		public Note(string note)
		{
			this.note = note;
		}

		public void AddNote(string note)
		{
			this.note = note;
		}
		
		public override string ToString()
		{
			return $"Id: {Id}, Note: {note}";
		}
	}
}