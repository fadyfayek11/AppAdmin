using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class News
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Title (English)")]
	public string Title { get; set; }

    [Display(Name = "Title (Arabic)")]
	public string TitleAr { get; set; }

    [Display(Name="Cover Image")]
    public string CoverImagePath { get; set; }

    [Display(Name = "English Content")]
    public string ContentEn { get; set; }

    [Display(Name = "Arabic Content")]
	public string ContentAr { get; set; }

	[Display(Name = "Published CheckInDate")]
	public DateTime DatePublished { get; set; } = DateTime.Now;
}