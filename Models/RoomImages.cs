using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models
{
    public class RoomImages
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public int RoomId { get; set; }

        // Navigation property
        public virtual Room Room { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
