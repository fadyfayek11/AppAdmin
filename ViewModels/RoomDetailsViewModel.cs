using System.ComponentModel.DataAnnotations;

namespace App.Admin.ViewModels;

public class RoomDetailsViewModel
{
	public int Id { get; set; }

    [Display(Name = "Room Name (Arabic)")]
    public string NameAr { get; set; }

    [Display(Name = "Room Name (English)")]
    public string NameEn { get; set; }

    [Display(Name = "Room Description (English)")]
    public string DescriptionEn { get; set; }

    [Display(Name = "Room Description (Arabic)")]
    public string DescriptionAr { get; set; }
	public double Price { get; set; }
	public double Size { get; set; }

    [Display(Name = "Max Occupancy")]
    public int MaxOccupancy { get; set; }
	public bool IsAvailable { get; set; } = true;

	[Display(Name = "Allow Smoking")]
	public bool AllowSmoking { get; set; }
    public List<RoomDetailsModel> RoomDetails { get; set; } = new List<RoomDetailsModel>();

    [Display(Name = "Room Images")]
    public List<IFormFile>? RoomImages { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;


}

public class RoomDetailsModel
{
	public int? RoomId { get; set; }
	[Required(ErrorMessage = "Room detail name (English) is required.")]
	[Display(Name = "Room Detail Name (English)")]
    public string RoomDetailNameEn { get; set; }

    [Required(ErrorMessage = "Room detail name (Arabic) is required.")]
	[Display(Name = "Room Detail Name (Arabic)")]
    public string RoomDetailNameAr { get; set; }
    public List<DetailsDescription> Descriptions { get; set; } = new List<DetailsDescription>();

    [Display(Name = "Icon")]
    public IFormFile? RoomIcon { get; set; }

    [Display(Name = "Display Icon?")]
    public bool IsIcon { get; set; } = false;
}

public class DetailsDescription
{
    public int? RoomDetailsId { get; set; }

    [Display(Name = "Room Description (English)")]
    public string? RoomDescriptionEn { get; set; }

    [Display(Name = "Room Description (Arabic)")]
    public string? RoomDescriptionAr { get; set; }
}