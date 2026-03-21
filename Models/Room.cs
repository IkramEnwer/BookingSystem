namespace BookingSystem.Models;

public class Room
{
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public int Kapasitet { get; set; }
    public string Sted { get; set; }
    public List<Booking> Bookings { get; set; }
}