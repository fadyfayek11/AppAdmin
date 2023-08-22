using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class Testimony
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string TitleAr { get; set; }
    public string Description { get; set; }
    public string DescriptionAr { get; set; }
    [Display(Name = "User Name")]
    public string UserName { get; set; }
    [Display(Name = "User Job")]
    public string UserJob { get; set; }
    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}