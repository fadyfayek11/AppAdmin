using System.Security.Principal;

namespace App.Admin.ViewModels;

public class ImagesModel
{
    public string Key { get; set; } = "OurTeam";
    public List<IFormFile> Images { get; set; }
}