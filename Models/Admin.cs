using System.ComponentModel.DataAnnotations;
using MarminaAttendance.Identity;

namespace App.Admin.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public bool IsRoot  { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ApplicationUser User { get; set; }

    }
}
