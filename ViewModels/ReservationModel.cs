namespace App.Admin.ViewModels;

public class ReservationModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string PhoneNumber { get; set; }
    public bool WithBreakFast { get; set; }
    public string Status { get; set; }
    public string CheckInDate { get; set; }
    public string CreatedDate { get; set; }
}