using System;

namespace Experiments.Models.Data
{
    public class DataModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public long ForeignKey { get; set; }
    }
}