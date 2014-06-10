using System.Linq;
using System.Net;
using System.Web.Mvc;
using @MvcNameSpace@.Models;
using @NameSpace@.Mapping;
using @NameSpace@.Services;
using PagedList;

namespace @MvcNameSpace@.Controllers
{
    public class @ClassName@Controller : Controller
    {
        private readonly @ClassName@Service _db = new @ClassName@Service();

        public ActionResult Index(int? page)
        {
            var @ClassNameLower@ = _db.GetAll().Select(e => (@ClassName@Model)e).ToList();
            return View(@ClassNameLower@.ToList().ToPagedList(page ?? 1, PageConfig.PageSize));
        }
		
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(@ClassName@Model @ClassNameLower@)
        {
            if (ModelState.IsValid)
            {
                _db.Insert(@ClassNameLower@);
                return RedirectToAction("Index");
            }
            return View(@ClassNameLower@);
        }
		
@Details@
@Edit@
@Delete@
    }
}