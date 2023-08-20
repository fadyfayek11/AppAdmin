using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Admin.ViewModels;

public class NewsModel
{
	public int? Id { get; set; }
    public string Title { get; set; }

    [Display(Name = "Cover Image")]
    public IFormFile? CoverImagePath { get; set; }
    public string? Path { get; set; }

    [Display(Name = "English Content")]
    public string ContentEn { get; set; }

    [Display(Name = "Arabic Content")]
    public string ContentAr { get; set; }
}