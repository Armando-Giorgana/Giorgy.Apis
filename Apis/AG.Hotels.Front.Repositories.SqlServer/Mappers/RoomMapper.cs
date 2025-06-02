using AG.Hotels.Front.Models;
using AG.Repositories.SqlServer.Entities;

namespace AG.Repositories.SqlServer.Mappers;

public static class RoomMapper
{
    public static RoomModel ToModel(this RoomEntity entity)
        => new ()
        {
            Id = entity.Id,
            Number = entity.Number,
            Type = entity.Type
        };
    
    public static IList<RoomModel> ToModel(this IList<RoomEntity> entities)
        => entities.Select(e => e.ToModel()).ToList();
    
    public static RoomEntity ToEntity(this RoomModel model)
        => new ()
        {
            Id = model.Id,
            Number = model.Number,
            Type = model.Type
        };
    
    public static IList<RoomEntity> ToEntity(this IList<RoomModel> models)
        => models.Select(m => m.ToEntity()).ToList();
}