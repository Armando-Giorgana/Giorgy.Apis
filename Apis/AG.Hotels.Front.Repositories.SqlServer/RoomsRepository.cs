using AG.Hotels.Front.Models;
using AG.Repositories.SqlServer.Entities;
using AG.Repositories.SqlServer.Mappers;
using AG.Repositories.SqlServer.Utils;

namespace AG.Repositories.SqlServer;

public interface IRoomsRepository : IBaseRepository<long, RoomModel>;

public class RoomsRepository(
    IDataStoreMockup dataStoreMockup
) : BaseRepository<long, RoomModel, RoomEntity>(dataStoreMockup), IRoomsRepository
{
    public override RoomModel? GetById(long id)
        => Database.Rooms.FirstOrDefault(x => x.Id == id)!.ToModel();

    public override IList<RoomModel> GetAll()
        => Database.Rooms.ToModel();

    public override RoomModel Create(RoomModel model)
    {
        var entity = model.ToEntity();

        var id = Database.Rooms
            .Select(x => x.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        entity.Id = id;
        
        if (Database.Rooms.FirstOrDefault(x => x.Number == entity.Number) is not null)
            throw new ArgumentException($"Room with number {entity.Number} already exists.");

        Database.Rooms.Add(entity);

        return GetById(entity.Id)!;
    }

    public override RoomModel Update(RoomModel model)
    {
        var find = Database.Rooms.FirstOrDefault(x => x.Id == model.Id);

        if (find == null)
            throw new KeyNotFoundException($"Room with id {model.Id} not found.");
        
        if (Database.Rooms.FirstOrDefault(x => x.Number == model.Number) is not null)
            throw new ArgumentException($"Room with number {model.Number} already exists.");

        var entity = model.ToEntity();

        Database.Rooms.Remove(find);
        Database.Rooms.Add(entity);

        return GetById(entity.Id)!;
    }

    public override void Delete(long id)
    {
        var find = Database.Rooms.FirstOrDefault(x => x.Id == id);

        if (find == null)
            throw new KeyNotFoundException($"Room with id {id} not found.");

        Database.Rooms.Remove(find);
    }
}