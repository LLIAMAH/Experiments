namespace WebApp.Models.View
{
    public class ProgramTableRow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal SumInsured { get; set; }
        public decimal CoverPrc { get; set; }
        public decimal SumPerVisit { get; set; }
        public int VisitPerPolicy { get; set; }
        public string ProgramType { get; set; }
        public decimal SumPerVisitNc { get; set; }
        public decimal Premium { get; set; }
        public bool Manual { get; set; }

        public bool HasSub { get; set; }
        public long RootId { get; set; }
    }
}