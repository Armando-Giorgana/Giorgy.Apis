using AG.Hotels.Front.Models.Enums;
using AG.Repositories.SqlServer.Entities;

namespace AG.Repositories.SqlServer;

public interface IDataStoreMockup
{
    IList<HotelEntity> Hotels { get; set; }
    IList<RoomEntity> Rooms { get; set; }
}

public class HotelFrontDataStoreMockup : IDataStoreMockup
{
    public IList<HotelEntity> Hotels { get; set; }
    public IList<RoomEntity> Rooms { get; set; }

    public HotelFrontDataStoreMockup()
    {
        Hotels = new List<HotelEntity>
        {
            new () { Id = 1, Name = "Park Royal Cancun", Enabled = true },
            new () { Id = 2, Name = "Park Royal Cozumel", Enabled = true },
            new () { Id = 3, Name = "Princess", Enabled = true },
            new () { Id = 4, Name = "Xcaret Hotel", Enabled = true },
            new () { Id = 5, Name = "Hotel C", Enabled = false }
        };
        
        Rooms = new List<RoomEntity>
        {
            new () { Id = 1, Number = 101, Type = RoomTypeEnum.Single, HotelId = 1 },
            new () { Id = 2, Number = 102, Type = RoomTypeEnum.Single, HotelId = 1 },
            new () { Id = 3, Number = 103, Type = RoomTypeEnum.Double, HotelId = 1 },
            new () { Id = 4, Number = 104, Type = RoomTypeEnum.Family, HotelId = 1 },
            new () { Id = 5, Number = 201, Type = RoomTypeEnum.Double, HotelId = 2 },
            new () { Id = 6, Number = 202, Type = RoomTypeEnum.Double, HotelId = 2 },
            new () { Id = 7, Number = 203, Type = RoomTypeEnum.Suite, HotelId = 2 },
            new () { Id = 8, Number = 301, Type = RoomTypeEnum.Deluxe, HotelId = 3 },
            new () { Id = 9, Number = 302, Type = RoomTypeEnum.Deluxe, HotelId = 3 },
            new () { Id = 10, Number = 401, Type = RoomTypeEnum.Family, HotelId = 4 },
            new () { Id = 11, Number = 402, Type = RoomTypeEnum.Family, HotelId = 4 },
            new () { Id = 13, Number = 403, Type = RoomTypeEnum.Suite, HotelId = 4 }
        };
    }
}