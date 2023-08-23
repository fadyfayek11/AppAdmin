using System.Security.Principal;

namespace App.Admin.ViewModels;

public class ImagesModel
{
    public string? Key { get; set; }
    public int? Id { get; set; }
    public List<IFormFile> Images { get; set; }
}