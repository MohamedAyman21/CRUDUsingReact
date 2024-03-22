using System.ComponentModel.DataAnnotations;

namespace CRUDUsingReact.Models
{
	public class Employee:PublicBaseClass
	{
		public string? Name { get; set; }
		[Range(20,118)]
		public int Age { get; set; }
		public bool IsActive { get; set; }
	}
}
