using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class Testimony
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
    public string UserJob { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}