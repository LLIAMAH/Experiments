using System.Collections.Generic;

namespace WebApp.Models.Reps
{
    public interface IRepSimple<in TId, T>
    {
        List<T> Get(string filter = null);
        List<T> GetDependent(TId id);

        List<T> Add(T item);
        List<T> Delete(TId id);
    }
}