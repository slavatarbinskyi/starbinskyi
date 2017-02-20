using System.ComponentModel.DataAnnotations;

namespace Model.DB
{
	public class InviteUser
	{
		[Key]
		public int Id { get; set; }

		public string Email { get; set; }
		public string GuidId { get; set; }
	}
}