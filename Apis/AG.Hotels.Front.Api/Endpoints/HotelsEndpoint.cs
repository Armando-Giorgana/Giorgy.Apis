using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;

namespace AG.Hotels.Front.Api.Endpoints;

public interface IHotelsEndpoint
{
    IList<HotelModel> GetHotels();
    HotelModel? GetHotelById(long id);
    HotelModel CreateHotel(HotelModel model);
    HotelModel UpdateHotel(long id, HotelModel model);
    void DeleteHotel(long id);
}

public class HotelsEndpoint(IHotelsService service) : IHotelsEndpoint
{
    public IList<HotelModel> GetHotels()
        => service.GetAll();

    public HotelModel? GetHotelById(long id)
        => service.GetById(id);

    public HotelModel CreateHotel(HotelModel model)
        => service.Create(model);

    public HotelModel UpdateHotel(long id, HotelModel model)
    {
        model.Id = id;
        
        return service.Update(model);
    }

    public void DeleteHotel(long id)
        => service.Delete(id);
}