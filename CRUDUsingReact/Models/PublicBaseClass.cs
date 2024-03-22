using System.ComponentModel.DataAnnotations;

namespace CRUDUsingReact.Models
{
	public class PublicBaseClass
	{
		[Key]
		public Guid ID { get; set; }
	}
}
