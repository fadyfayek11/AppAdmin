using System.ComponentModel.DataAnnotations;
using SnapatHotel.Models;

namespace App.Admin.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public int MaxOccupancy { get; set; }
        public bool IsAvailable { get; set; }
        public bool AllowSmoking { get; set; }
        public ICollection<RoomDetails>? RoomDetails { get; set; }
        public ICollection<RoomImages>? RoomImages { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
