using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.ViewModels;

public class AboutModel
{
	[Key]
	public int Id { get; set; }
	public List<string> AboutImages { get; set; }
		
	public string AboutTitleEn { get; set; }
		
	public string AboutTitleAr { get; set; }
	public string AboutAr { get; set; }

	public string AboutEn { get; set; }

}

public class CoverText
{
	[Key]
	public int Id { get; set; }
	public string CoverTextAr { get; set; }
	public string CoverTextEn { get; set; }

	public string CoverImage { get; set; }
}

