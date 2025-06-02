using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;
using AG.Repositories.SqlServer;
using Microsoft.Extensions.Logging;

namespace AG.Hotels.Front.Services;

public class RoomsService(
    IRoomsRepository repository,
    ILoggerFactory loggerFactory
) : BaseService<long, RoomModel, IRoomsRepository>(repository, loggerFactory), IRoomsService;