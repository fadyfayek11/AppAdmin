using System.ComponentModel.DataAnnotations;
using SnapatHotel.Models;

namespace App.Admin.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "User Name")]
	public string UserName { get; set; }

	[Display(Name = "User Email")]
	public string UserEmail { get; set; }
	[Display(Name = "Phone Number")]
	public string PhoneNumber { get; set; }

	[Display(Name = "With BreakFast")]
	public bool WithBreakFast { get; set; }

    public ReservationStatus Status { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int RoomId { get; set; }

    // Navigation property
    public virtual Room Room { get; set; }
}