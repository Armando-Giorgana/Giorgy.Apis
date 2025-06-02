using AG.Hotels.Front.Services.Interfaces;
using AG.Repositories.SqlServer.Utils;
using Microsoft.Extensions.Logging;

namespace AG.Hotels.Front.Services;

public abstract class BaseService<TKey, TModel, TRepository>(
    TRepository repository,
    ILoggerFactory loggerFactory
) : IBaseService<TKey, TModel>
    where TKey : struct
    where TModel : class
    where TRepository : IBaseRepository<TKey, TModel>
{
    protected TRepository Repository { get; } = repository;
    protected ILogger Logger { get;  } = loggerFactory.CreateLogger<BaseService<TKey, TModel, TRepository>>();

    public virtual TModel? GetById(TKey id)
        => Repository.GetById(id);
    
    public virtual IList<TModel> GetAll()
        => Repository.GetAll();

    public virtual TModel Create(TModel model)
    {
        Logger.LogInformation("Creating new {model}", typeof(TModel).Name);
        
        var result = Repository.Create(model);
        
        Logger.LogInformation("New {model} created successfully", typeof(TModel).Name);
        
        return result;
    }

    public virtual TModel Update(TModel model)
    {
        Logger.LogInformation("Updating {model}", typeof(TModel).Name);
        
        var result = Repository.Update(model);
        
        Logger.LogInformation("{model} updated successfully", typeof(TModel).Name);
        
        return result;
    }

    public virtual void Delete(TKey id)
    {
        Logger.LogInformation("Deleting {model} with id {id}", typeof(TModel).Name, id);
        
        Repository.Delete(id);
        
        Logger.LogInformation("{model} with id {id} deleted successfully", typeof(TModel).Name, id);
    }
}