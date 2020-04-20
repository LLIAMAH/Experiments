using System.Collections.Generic;
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
                return PartialView("ProgramDbTableRow", new List<ProgramTableRow>());

            var result = _rep.GetDependent(dependentId.Value);
            return PartialView("ProgramDbTableRow", result);
        }
    }
}