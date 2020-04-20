using System.Collections.Generic;

namespace WebApp.Models.Reps
{
    public interface IRepSimple<TId, T>
    {
        List<T> Get(string filter = null);
        List<T> GetDependent(TId id, TId rootId);

        List<T> Add(T item);
        List<T> Delete(TId id);
        T Update(TId id, T item);
    }
}