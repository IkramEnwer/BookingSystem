namespace BookingSystem.Models;

public class User
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public List<Booking> Bookings { get; set; }
}