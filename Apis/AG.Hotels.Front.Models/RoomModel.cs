using AG.Hotels.Front.Models.Enums;

namespace AG.Hotels.Front.Models;

public class RoomModel
{
    public long Id { get; set; }
    public int Number { get; set; }
    public RoomTypeEnum Type { get; set; }
}