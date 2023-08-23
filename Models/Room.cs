using System.ComponentModel.DataAnnotations;
using SnapatHotel.Models;

namespace App.Admin.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name (Arabic)")]
        public string NameAr { get; set; }

        [Display(Name = "Name (English)")]
        public string NameEn { get; set; }

        [Display(Name = "Description (English)")]
        public string DescriptionEn { get; set; }

        [Display(Name = "Description (Arabic)")]
        public string DescriptionAr { get; set; }

        public double Price { get; set; }
        public double Size { get; set; }
        [Display(Name = "Max Occupancy")]
        public int MaxOccupancy { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Allow Smoking")]
        public bool AllowSmoking { get; set; }
        public ICollection<RoomDetails>? RoomDetails { get; set; }
        public ICollection<RoomImages>? RoomImages { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
