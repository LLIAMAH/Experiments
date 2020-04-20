using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Models.Data
{
    public class DropDownExampleModel
    {
        public string MainDropDownId { get; set; }
        public IEnumerable<SelectListItem> SelectListItems { get; set; }
        public string DependentId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}