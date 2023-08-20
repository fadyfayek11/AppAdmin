using System.ComponentModel.DataAnnotations;

namespace App.Admin.ViewModels;

public class AdminUser
{
	public string? Id { get; set; }
	[Required(ErrorMessage = "Name is required")]
	public string Name { get; set; }

	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email format")]
	public string Email { get; set; }

	[RegularExpression(@"^[0-9]*$", ErrorMessage = "Mobile must contain numbers only")] 
	public string Mobile { get; set; }

	[StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
	public string? Password { get; set; }
	public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsRoot { get; set; }
}