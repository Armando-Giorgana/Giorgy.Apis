using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;
using AG.Repositories.SqlServer;

namespace AG.Hotels.Front.Services;

public class RoomsService(
    IRoomsRepository repository
) : BaseService<long, RoomModel, IRoomsRepository>(repository), IRoomsService;