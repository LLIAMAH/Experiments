using System.Web.Mvc;
using Experiments.Models.Rep;

namespace Experiments.Controllers
{
    public class HomeController : Controller
    {
        private static IRep _rep;

        public HomeController()
        {
            if (_rep == null)
                _rep = new Rep();
        }

        public ActionResult Index()
        {
            return View(_rep.Get(null));
        }

        [HttpPost]
        public PartialViewResult Filter(string filter)
        {
            var t = _rep.Get(filter);
            return PartialView("TableOutput", t);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}