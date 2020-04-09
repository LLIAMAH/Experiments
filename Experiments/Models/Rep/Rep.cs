using System;
using System.Collections.Generic;
using System.Linq;
using Experiments.Models.Data;

namespace Experiments.Models.Rep
{
    public interface IRep
    {
        List<DataModel> Get(string filter);
        List<DataModel> GetDependent(long id);
        List<DataModel> Add(DataModel item);
        List<DataModel> Delete(long id);
    }

    public class Rep : IRep
    {
        private static List<DataModel> _list;
        private static List<DataModel> _dependentList;

        public Rep()
        {
            // default data for test
            _list = new List<DataModel>()
            {
                new DataModel() {Id = 1, Title = "Title 1", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 2, Title = "Title 2", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 3, Title = "Title 3", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 4, Title = "Title 4", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 5, Title = "Not Title 1", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 6, Title = "Not Title 2", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 7, Title = "Not Title 3", Date = DateTime.Now, ForeignKey = 0},
                new DataModel() {Id = 8, Title = "Not Title 4", Date = DateTime.Now, ForeignKey = 0}
            };

            _dependentList = new List<DataModel>()
            {
                new DataModel() {Id = 9, Title = "Dependency Title 1", Date = DateTime.Now, ForeignKey = 1},
                new DataModel() {Id = 10, Title = "Dependency Title 2", Date = DateTime.Now, ForeignKey = 1},
                new DataModel() {Id = 11, Title = "Dependency Title 3", Date = DateTime.Now, ForeignKey = 1},
                new DataModel() {Id = 12, Title = "Dependency Title 4", Date = DateTime.Now, ForeignKey = 2},
                new DataModel() {Id = 13, Title = "Dependency Title 5", Date = DateTime.Now, ForeignKey = 2},
                new DataModel() {Id = 14, Title = "Dependency Title 6", Date = DateTime.Now, ForeignKey = 3},
                new DataModel() {Id = 15, Title = "Dependency Title 7", Date = DateTime.Now, ForeignKey = 3},
                new DataModel() {Id = 16, Title = "Dependency Title 8", Date = DateTime.Now, ForeignKey = 3},
                new DataModel() {Id = 17, Title = "Dependency Title 9", Date = DateTime.Now, ForeignKey = 3},
                new DataModel() {Id = 18, Title = "Dependency Title 10", Date = DateTime.Now, ForeignKey = 4},
                new DataModel() {Id = 19, Title = "Dependency Title 11", Date = DateTime.Now, ForeignKey = 4},
                new DataModel() {Id = 20, Title = "Dependency Title 12", Date = DateTime.Now, ForeignKey = 4},
                new DataModel() {Id = 21, Title = "Dependency Title 13", Date = DateTime.Now, ForeignKey = 5},
                new DataModel() {Id = 22, Title = "Dependency Title 14", Date = DateTime.Now, ForeignKey = 6},
                new DataModel() {Id = 23, Title = "Dependency Title 15", Date = DateTime.Now, ForeignKey = 6},
                new DataModel() {Id = 24, Title = "Dependency Title 16", Date = DateTime.Now, ForeignKey = 7},
                new DataModel() {Id = 25, Title = "Dependency Title 17", Date = DateTime.Now, ForeignKey = 8},
                new DataModel() {Id = 26, Title = "Dependency Title 18", Date = DateTime.Now, ForeignKey = 8},
                new DataModel() {Id = 27, Title = "Dependency Title 19", Date = DateTime.Now, ForeignKey = 8},
                new DataModel() {Id = 28, Title = "Dependency Title 20", Date = DateTime.Now, ForeignKey = 8},
                new DataModel() {Id = 29, Title = "Dependency Title 21", Date = DateTime.Now, ForeignKey = 8},
                new DataModel() {Id = 30, Title = "Dependency Title 22", Date = DateTime.Now, ForeignKey = 8},
            };
        }

        public List<DataModel> Get(string filter)
        {
            if (filter == null)
                return _list;

            return _list.Where(o => o.Title.ToLower().Contains(filter.ToLower()))
                .ToList();
        }

        public List<DataModel> GetDependent(long id)
        {
            return _dependentList
                .Where(o => o.ForeignKey == id)
                .ToList();
        }

        public List<DataModel> Add(DataModel item)
        {
            var existing = _list
                .FirstOrDefault(o => o.Title.Equals(item.Title, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                return _list; // Already existing.

            var maxId = _list.Max(o => o.Id);
            item.Id = maxId + 1;

            _list?.Add(item);
            return _list;
        }

        public List<DataModel> Delete(long id)
        {
            var item = _list.SingleOrDefault(o => o.Id == id);
            if (item != null)
                _list.Remove(item);

            return _list;
        }
    }
}