using AG.Hotels.Front.Models.Enums;

namespace AG.Repositories.SqlServer.Entities;
// TODO: Add RepoDB attribute to this class
public class RoomEntity
{
    public long Id { get; set; }
    public int Number { get; set; }
    public RoomTypeEnum Type { get; set; }
    
    public int HotelId { get; set; }
}