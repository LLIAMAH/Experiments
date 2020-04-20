using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Data;
using WebApp.Models.View;

namespace WebApp.Models.Reps
{
    public class RepTable : IRepSimple<long, ProgramTableRow>
    {
        private static List<ProgramDbTableRow> _list;

        public RepTable()
        {
            if (_list == null)
            {
                _list = new List<ProgramDbTableRow>()
                {
                    new ProgramDbTableRow(){Id = 1, Name = "Prog1", PremiumPerPerson = 300, ParentId = null, LimitLevel = 300, LimitTypeCode = "Test1", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 2, Name = "Prog2", PremiumPerPerson = 300, ParentId = null, LimitLevel = 300, LimitTypeCode = "Test2", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType2", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 3, Name = "Prog3", PremiumPerPerson = 300, ParentId = null, LimitLevel = 300, LimitTypeCode = "Test2", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType3", SumPerVisitNc = 10, Premium = 3000, Manual = false },

                    new ProgramDbTableRow(){Id = 4, Name = "Prog4", PremiumPerPerson = 300, ParentId = 1, LimitLevel = 300, LimitTypeCode = "Test3", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 5, Name = "Prog5", PremiumPerPerson = 300, ParentId = 1, LimitLevel = 300, LimitTypeCode = "Test3", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 6, Name = "Prog6", PremiumPerPerson = 300, ParentId = 1, LimitLevel = 300, LimitTypeCode = "Test3", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 7, Name = "Prog7", PremiumPerPerson = 300, ParentId = 1, LimitLevel = 300, LimitTypeCode = "Test1", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },

                    new ProgramDbTableRow(){Id = 8, Name = "Prog8", PremiumPerPerson = 300, ParentId = 4, LimitLevel = 300, LimitTypeCode = "Test6", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 9, Name = "Prog9", PremiumPerPerson = 300, ParentId = 4, LimitLevel = 300, LimitTypeCode = "Test6", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },

                    new ProgramDbTableRow(){Id = 10, Name = "Prog10", PremiumPerPerson = 300, ParentId = null, LimitLevel = 300, LimitTypeCode = "Test1", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                    new ProgramDbTableRow(){Id = 11, Name = "Prog11", PremiumPerPerson = 300, ParentId = null, LimitLevel = 300, LimitTypeCode = "Test1", SumInsured = 3000, CoverPrc = 100, SumPerVisit = 20, VisitPerPolicy = 10, ProgramType = "ProgType1", SumPerVisitNc = 10, Premium = 3000, Manual = false },
                };
            }
        }

        public List<ProgramTableRow> Get(string filter = null)
        {
            return _list.Where(o => o.ParentId == null)
                .Select(o => new ProgramTableRow()
                {
                    Id = o.Id,
                    Manual = o.Manual,
                    Premium = o.Premium,
                    CoverPrc = o.CoverPrc,
                    Name = o.Name,
                    ProgramType = o.ProgramType,
                    SumInsured = o.SumInsured,
                    SumPerVisit = o.SumPerVisit,
                    SumPerVisitNc = o.SumPerVisitNc,
                    VisitPerPolicy = o.VisitPerPolicy,
                    RootId = o.Id,
                    HasSub = GetDependent(o.Id, o.Id).Any()
                })
                .ToList();
        }

        public List<ProgramTableRow> GetDependent(long id, long rootId)
        {
            return _list.Where(o => o.ParentId == id)
                .Select(o=> new ProgramTableRow()
                {
                    Id = o.Id,
                    Manual = o.Manual,
                    Premium = o.Premium,
                    CoverPrc = o.CoverPrc,
                    Name = o.Name,
                    ProgramType = o.ProgramType,
                    SumInsured = o.SumInsured,
                    SumPerVisit = o.SumPerVisit,
                    SumPerVisitNc = o.SumPerVisitNc,
                    VisitPerPolicy = o.VisitPerPolicy,
                    RootId = rootId,
                    HasSub = GetDependent(o.Id, rootId).Any()
                })
                .ToList();
        }

        public List<ProgramTableRow> Add(ProgramTableRow item)
        {
            return Get();
        }

        public List<ProgramTableRow> Delete(long id)
        {
            return Get();
        }

        public ProgramTableRow Update(long id, ProgramTableRow item)
        {
            var existing = _list.FirstOrDefault(o => o.Id == id);
            if (existing == null)
                return null;

            existing.Apply(item);
            var root = GetParent(existing.Id);
            if (root == null)
                return null;

            return new ProgramTableRow()
            {
                Id = root.Id,
                Manual = root.Manual,
                Premium = root.Premium,
                CoverPrc = root.CoverPrc,
                Name = root.Name,
                ProgramType = root.ProgramType,
                SumInsured = root.SumInsured,
                SumPerVisit = root.SumPerVisit,
                SumPerVisitNc = root.SumPerVisitNc,
                VisitPerPolicy = root.VisitPerPolicy,
                HasSub = GetDependent(root.Id, root.Id).Any()
            };
        }

        private ProgramDbTableRow GetParent(long itemId)
        {
            var item = _list.SingleOrDefault(o => o.Id == itemId);
            if (item == null)
                return null;

            if (item.ParentId == null || item.ParentId.Value == 0)
                return item;

            return GetParent(item.ParentId.Value);
        }
    }
}