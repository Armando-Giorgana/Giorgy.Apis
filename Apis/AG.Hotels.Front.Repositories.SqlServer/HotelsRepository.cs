using AG.Hotels.Front.Models;
using AG.Repositories.SqlServer.Entities;
using AG.Repositories.SqlServer.Mappers;
using AG.Repositories.SqlServer.Utils;

namespace AG.Repositories.SqlServer;

public interface IHotelsRepository : IBaseRepository<long, HotelModel>;

public class HotelsRepository(
    IDataStoreMockup dataStoreMockup
) : BaseRepository<long, HotelModel, HotelEntity>(dataStoreMockup), IHotelsRepository
{
    public override HotelModel? GetById(long id)
    {
        var relatedRooms = Database.Rooms
            .Where(x => x.HotelId == id)
            .ToList();
        
        var hotel = Database.Hotels.FirstOrDefault(x => x.Id == id)!
            .ToModel(relatedRooms);
        
        return hotel;
    }

    public override IList<HotelModel> GetAll()
        => Database.Hotels.ToModel();

    public override HotelModel Create(HotelModel model)
    {
        var entity = model.ToEntity();
        
        var id =  Database.Hotels
            .Select(x => x.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;
        
        entity.Id = id;
        
        Database.Hotels.Add(entity);
        
        return GetById(entity.Id)!;
    }

    public override HotelModel Update(HotelModel model)
    {
        var find = Database.Hotels.FirstOrDefault(x => x.Id == model.Id);
        
        if (find == null)
            throw new KeyNotFoundException($"Hotel with id {model.Id} not found.");
        
        var entity = model.ToEntity();

        Database.Hotels.Remove(find);
        Database.Hotels.Add(entity);
        
        return GetById(entity.Id)!;
    }

    public override void Delete(long id)
    {
        var find = Database.Hotels.FirstOrDefault(x => x.Id == id);
        
        if (find == null)
            throw new KeyNotFoundException($"Hotel with id {id} not found.");
        
        Database.Hotels.Remove(find);
    }
}