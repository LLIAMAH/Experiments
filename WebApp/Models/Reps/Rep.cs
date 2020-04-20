using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Data;

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