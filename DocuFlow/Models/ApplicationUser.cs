using Microsoft.AspNetCore.Identity;

namespace DocuFlow.Models
{
	public class ApplicationUser : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Position { get; set; }
		public required string Organisation { get; set; }
	}
}
