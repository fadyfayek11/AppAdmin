using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Details (English)")]
        public string DetailNameEn { get; set; }

        [Display(Name = "Details (Arabic)")]
		public string DetailNameAr { get; set; }
		[Display(Name = "Description (English)")]
		public string? DescriptionEn { get; set; }
		[Display(Name = "Description (Arabic)")]
		public string? DescriptionAr { get; set; }

        public bool IsIcon { get; set; }

        public int RoomId { get; set; }

        // Navigation property
        public virtual Room Room { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
