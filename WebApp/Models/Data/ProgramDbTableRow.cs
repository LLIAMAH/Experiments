using WebApp.Models.View;

namespace WebApp.Models.Data
{
    public class ProgramDbTableRow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal PremiumPerPerson { get; set; }

        public long? ParentId { get; set; }
        public decimal LimitLevel { get; set; }
        public string LimitTypeCode { get; set; }
        public decimal SumInsured { get; set; }
        public decimal CoverPrc { get; set; }
        public decimal SumPerVisit { get; set; }
        public int VisitPerPolicy { get; set; }
        public string ProgramType { get; set; }
        public decimal SumPerVisitNc { get; set; }
        public decimal Premium { get; set; }
        public bool Manual { get; set; }
    }

    public static class ProgramTableRowEx
    {
        public static void Apply(this ProgramDbTableRow item, ProgramTableRow model)
        {
            item.Id = model.Id;
            item.Name = model.Name;
            item.SumInsured = model.SumInsured;
            item.CoverPrc = model.CoverPrc;
            item.SumPerVisit = model.SumPerVisit;
            item.VisitPerPolicy = model.VisitPerPolicy;
            item.ProgramType = model.ProgramType;
            item.SumPerVisitNc = model.SumPerVisitNc;
            item.Premium = model.Premium;
            item.Manual = model.Manual;
        }
    }
}