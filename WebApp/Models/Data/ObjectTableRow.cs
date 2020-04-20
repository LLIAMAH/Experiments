namespace WebApp.Models.Data
{
    public class ProgramDbTableRow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal PremiumPerPerson { get; set; }

        public long ParentId { get; set; }
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
}