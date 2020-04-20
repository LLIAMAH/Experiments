using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Data;

namespace WebApp.Models.Reps
{
    public class RepTable : IRepSimple<long, ProgramDbTableRow>
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

        public List<ProgramDbTableRow> Get(string filter = null)
        {
            return _list.Where(o => o.ParentId == null).ToList();
        }

        public List<ProgramDbTableRow> GetDependent(long id)
        {
            return _list.Where(o => o.ParentId == id)
                .ToList();
        }

        public List<ProgramDbTableRow> Add(ProgramDbTableRow item)
        {
            _list.Add(item);

            return _list;
        }

        public List<ProgramDbTableRow> Delete(long id)
        {
            var exists = _list.SingleOrDefault(o => o.Id == id);
            if (exists == null)
                return _list;

            _list.Remove(exists);
            return _list;
        }
    }
}