using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Data
{
    public class DataModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public long ForeignKey { get; set; }
    }
}