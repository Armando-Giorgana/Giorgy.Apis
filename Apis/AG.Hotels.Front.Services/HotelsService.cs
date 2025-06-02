using AG.Hotels.Front.Models;
using AG.Hotels.Front.Services.Interfaces;
using AG.Repositories.SqlServer;
using Microsoft.Extensions.Logging;

namespace AG.Hotels.Front.Services;

public class HotelsService(
    IHotelsRepository repository,
    ILoggerFactory loggerFactory
) : BaseService<long, HotelModel, IHotelsRepository>(repository, loggerFactory), IHotelsService;