using AG.Repositories.SqlServer.Entities;

namespace AG.Repositories.SqlServer.Utils;

public interface IBaseRepository<TKey, TModel>
    where TKey : struct
    where TModel : class
{
    TModel? GetById(TKey id);
    IList<TModel> GetAll();
    TModel Create(TModel model);
    TModel Update(TModel model);
    void Delete(TKey id);
}

public abstract class BaseRepository<TKey, TModel, TEntity>(
    IDataStoreMockup dataStoreMockup
    ) : IBaseRepository<TKey, TModel>
    where TKey : struct
    where TModel : class
    where TEntity : class
{
    protected IDataStoreMockup Database { get; private set; } = dataStoreMockup;
    
    public virtual TModel? GetById(TKey id)
    {
        throw new NotImplementedException();
    }

    public virtual IList<TModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual TModel Create(TModel model)
    {
        throw new NotImplementedException();
    }

    public virtual TModel Update(TModel model)
    {
        throw new NotImplementedException();
    }

    public virtual void Delete(TKey id)
    {
        throw new NotImplementedException();
    }
}