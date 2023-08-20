using System.ComponentModel.DataAnnotations;
using SnapatHotel.Models;

namespace App.Admin.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string PhoneNumber { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}