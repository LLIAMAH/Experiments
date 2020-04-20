using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using WebApp.Models.Reps;
using WebApp.Models.View;

namespace WebApp.Controllers
{
    public class TableDataController : Controller
    {
        private static IRepSimple<long, ProgramTableRow> _rep;

        public TableDataController()
        {
            if(_rep == null)
                _rep = new RepTable();
        }

        // GET: TableData
        public ActionResult Index()
        {
            return View(_rep.Get());
        }

        [HttpPost]
        public PartialViewResult GetDependent(long? dependentId)
        {
            if (dependentId == null)
                return PartialView("ProgramDbTable", new List<ProgramTableRow>());

            var result = _rep.GetDependent(dependentId.Value, 0);
            return PartialView("ProgramDbTable", result);
        }

        [HttpPost]
        public PartialViewResult EditTableRowItem(ProgramTableRow item)
        {
            if (ModelState.IsValid)
            {
                var result = _rep.Update(item.Id, item);
                return PartialView("~/Views/Shared/DisplayTemplates/ProgramTableRow.cshtml", result);
            }

            return null;
        }
    }
}