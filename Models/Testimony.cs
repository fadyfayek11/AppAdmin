using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class Testimony
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Title (English)")]
	public string Title { get; set; }

    [Display(Name = "Title (Arabic)")]
	public string TitleAr { get; set; }

    [Display(Name = "Description (English)")]
	public string Description { get; set; }

    [Display(Name = "Description (Arabic)")]
	public string DescriptionAr { get; set; }

    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "User Job")]
    public string UserJob { get; set; }

    [Display(Name = "Created CheckInDate")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}