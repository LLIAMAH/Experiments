using System.Web.Mvc;
using WebApp.Models.Data;
using WebApp.Models.Reps;

namespace WebApp.Controllers
{
    public class TableDataController : Controller
    {
        private static IRepSimple<long, ProgramDbTableRow> _rep;

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
    }
}