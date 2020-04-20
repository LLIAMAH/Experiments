using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Models.Data;
using WebApp.Models.Reps;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static IRepSimple<long, DataModel> _rep;
        public HomeController()
        {
            if (_rep == null)
                _rep = new RepSimple();
        }

        public ActionResult Index()
        {
            return View(_rep.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DataModel model)
        {
            if (ModelState.IsValid)
            {
                _rep.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Filter(string filter)
        {
            return PartialView("TableOutput", _rep.Get(filter));
        }

        [HttpPost]
        public JsonResult GetDependent(long? dependentId)
        {
            if (dependentId == null)
                return Json(new SelectList(new List<DataModel>(), "Id", "Title"));

            var result = _rep.GetDependent(dependentId.Value, 0);
            return Json(new SelectList(result, "Id", "Title"));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DropDownExample()
        {
            var model = new DropDownExampleModel()
            {
                SelectListItems = new SelectList(_rep.Get(), "Id", "Title"),
                Items = new SelectList(new List<DataModel>(), "Id", "Title")
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}