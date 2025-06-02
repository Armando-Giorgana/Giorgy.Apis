using AG.Hotels.Front.Models;
using AG.Repositories.SqlServer.Entities;

namespace AG.Repositories.SqlServer.Mappers;

public static class HotelMapper
{
    public static HotelModel ToModel(this HotelEntity entity, IList<RoomEntity> relatedEntities = null)
        => new ()
        {
            Id = entity.Id,
            Name = entity.Name,
            Enabled = entity.Enabled,
            Rooms = relatedEntities?.Where(r => r.HotelId == entity.Id)
                .Select(r => r.ToModel())
                .ToList() ?? new ()
        };
    
    public static IList<HotelModel> ToModel(this IList<HotelEntity> entities)
        => entities.Select(e => e.ToModel(null)).ToList();
    
    public static HotelEntity ToEntity(this HotelModel model)
        => new ()
        {
            Id = model.Id,
            Name = model.Name,
            Enabled = model.Enabled,
        };
    
    public static IList<HotelEntity> ToEntity(this IList<HotelModel> models)
        => models.Select(m => m.ToEntity()).ToList();
}