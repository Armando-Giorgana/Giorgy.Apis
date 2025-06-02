using AG.Hotels.Front.Services.Interfaces;
using AG.Repositories.SqlServer.Utils;

namespace AG.Hotels.Front.Services;

public abstract class BaseService<TKey, TModel, TRepository>(
    TRepository repository
    ) : IBaseService<TKey, TModel>
    where TKey : struct
    where TModel : class
    where TRepository : IBaseRepository<TKey, TModel>
{
    protected readonly TRepository Repository = repository;
    
    public TModel? GeById(TKey id)
        => Repository.GetById(id);
    
    public IList<TModel> GeAll()
        => Repository.GetAll();

    public TModel Create(TModel model)
        => Repository.Create(model);

    public TModel Update(TModel model)
        => Repository.Update(model);

    public void Delete(TKey id)
        => Repository.Delete(id);
}