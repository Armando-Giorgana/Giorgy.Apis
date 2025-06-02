namespace AG.Hotels.Front.Models;

public class HotelModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }
    
    public List<RoomModel> Rooms { get; set; } = new ();
}