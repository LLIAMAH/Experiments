using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Data;

namespace WebApp.Models.Reps
{
    public class RepSimple : IRepSimple<long, DataModel>
    {
        private static List<DataModel> _list;

        public RepSimple()
        {
            if (_list == null)
            {
                _list = new List<DataModel>()
                {
                    new DataModel() {Id = 1, Title = "Title 1", Date = DateTime.Now, ForeignKey = 0},
                    new DataModel() {Id = 2, Title = "Title 2", Date = DateTime.Now, ForeignKey = 0},
                    new DataModel() {Id = 3, Title = "Non Title 3", Date = DateTime.Now, ForeignKey = 0},
                    new DataModel() {Id = 4, Title = "Title 4", Date = DateTime.Now, ForeignKey = 1},
                    new DataModel() {Id = 5, Title = "Title 5", Date = DateTime.Now, ForeignKey = 1},
                    new DataModel() {Id = 6, Title = "Title 6", Date = DateTime.Now, ForeignKey = 1},
                    new DataModel() {Id = 7, Title = "Title 7", Date = DateTime.Now, ForeignKey = 1},
                    new DataModel() {Id = 8, Title = "Title 8", Date = DateTime.Now, ForeignKey = 2},
                    new DataModel() {Id = 9, Title = "Title 9", Date = DateTime.Now, ForeignKey = 2},
                    new DataModel() {Id = 10, Title = "Title 10", Date = DateTime.Now, ForeignKey = 3},
                    new DataModel() {Id = 11, Title = "Title 11", Date = DateTime.Now, ForeignKey = 3},
                    new DataModel() {Id = 12, Title = "Title 12", Date = DateTime.Now, ForeignKey = 3},
                    new DataModel() {Id = 13, Title = "Title 13", Date = DateTime.Now, ForeignKey = 2},
                    new DataModel() {Id = 14, Title = "Title 14", Date = DateTime.Now, ForeignKey = 2},
                    new DataModel() {Id = 15, Title = "Title 15", Date = DateTime.Now, ForeignKey = 2}
                };
            }
        }

        public List<DataModel> Get(string filter = null)
        {
            if (string.IsNullOrEmpty(filter))
                return _list.Where(o => o.ForeignKey == 0).ToList();

            return _list
                .Where(o => o.Title.ToLower().Contains(filter.ToLower()) && o.ForeignKey == 0)
                .ToList();
        }

        public List<DataModel> GetDependent(long id, long rootId)
        {
            return _list.Where(o => o.ForeignKey == id).ToList();
        }

        public List<DataModel> Add(DataModel item)
        {
            if (item == null)
                return Get(null);

            var existing = _list.FirstOrDefault(o => o.Title.Equals(item.Title, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                return Get(null);

            var maxId = _list.Max(o => o.Id) + 1;
            item.Id = maxId;
            item.Date = DateTime.Now;
            _list?.Add(item);
            return Get(null);
        }

        public List<DataModel> Delete(long id)
        {
            var existing = _list.FirstOrDefault(o => o.Id == id);
            if (existing == null)
                return Get(null);

            _list?.Remove(existing);
            return Get(null);
        }

        public DataModel Update(long id, DataModel item)
        {
            var existing = _list.FirstOrDefault(o => o.Id == id);
            if (existing == null)
                return null;

            existing = item;

            return existing;
        }
    }
}