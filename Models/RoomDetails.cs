using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }

        public string DetailNameEn { get; set; }

        public string DetailNameAr { get; set; }

        public string? DescriptionEn { get; set; }

        public string? DescriptionAr { get; set; }

        public bool IsIcon { get; set; }

        public int RoomId { get; set; }

        // Navigation property
        public virtual Room Room { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
