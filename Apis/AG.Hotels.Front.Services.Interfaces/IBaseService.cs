namespace AG.Hotels.Front.Services.Interfaces;

public interface IBaseService<TKey, TModel>
    where TKey : struct
    where TModel : class
{
    TModel? GetById(TKey  id);
    IList<TModel> GetAll();
    TModel Create(TModel model);
    TModel Update(TModel model);
    void Delete(TKey id);
}