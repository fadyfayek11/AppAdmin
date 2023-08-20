namespace App.Admin.ViewModels;

public class AdminUser
{

    public string? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsRoot { get; set; }
}