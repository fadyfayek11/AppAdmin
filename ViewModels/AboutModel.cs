using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.ViewModels;

public class AboutModel
{
	public int Id { get; set; }
	public List<string> AboutImages { get; set; }
    public string HeaderAr { get; set; }
    public string HeaderEn { get; set; }
    public string AboutAr { get; set; }
    public string AboutEn { get; set; }
}
public class EditAbout
{
    public int Id { get; set; }
    public string HeaderAr { get; set; }
    public string HeaderEn { get; set; }
    public string AboutAr { get; set; }
    public string AboutEn { get; set; }
    public IFormFile Image1 { get; set; }
    public IFormFile Image2 { get; set; }
    public IFormFile Image3 { get; set; }

}

public class CoverTexts
{
    public int Id { get; set; }
    public string HeaderAr { get; set; }
    public string HeaderEn { get; set; }
    public string CoverTextAr { get; set; }
	public string CoverTextEn { get; set; }
	public string CoverImage { get; set; }
}

public class CoverText
{
	public string HeaderAr { get; set; }
	public string HeaderEn { get; set; }
	public string CoverTextAr { get; set; }
	public string CoverTextEn { get; set; }
	public IFormFile CoverImage { get; set; }
}

