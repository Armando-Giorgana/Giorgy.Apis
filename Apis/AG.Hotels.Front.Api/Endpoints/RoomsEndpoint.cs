using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;

namespace AG.Hotels.Front.Api.Endpoints;

public interface IRoomsEndpoint
{
    IList<RoomModel> GetRooms();
    RoomModel? GetRoomById(long id);
    RoomModel CreateRoom(RoomModel model);
    RoomModel UpdateRoom(long id, RoomModel model);
    void DeleteRoom(long id);
}

public class RoomsEndpoint(IRoomsService service) : IRoomsEndpoint
{
    public IList<RoomModel> GetRooms()
        => service.GetAll();

    public RoomModel? GetRoomById(long id)
        => service.GetById(id);

    public RoomModel CreateRoom(RoomModel model)
        => service.Create(model);

    public RoomModel UpdateRoom(long id, RoomModel model)
    {
        model.Id = id;
        
        return service.Update(model);
    }

    public void DeleteRoom(long id)
        => service.Delete(id);
}