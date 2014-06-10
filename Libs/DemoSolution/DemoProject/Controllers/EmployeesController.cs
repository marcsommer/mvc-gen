using System.Linq;
using System.Net;
using System.Web.Mvc;
using DemoProject.Models;
using Northwind.Mapping;
using Northwind.Services;
using PagedList;

namespace DemoProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesService db = new EmployeesService();

        public ActionResult Index(int? page)
        {
            var employees = db.GetAll().Select(e => (EmployeModel)e).ToList();
            return View(employees.ToList().ToPagedList(page ?? 1, 8));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeModel employee = (EmployeModel) db.Find(e=>e.EmployeeID==id.Value).FirstOrDefault();
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeModel employee)
        {
            if (ModelState.IsValid)
            {
                db.Insert((Employees)employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeModel employee = (EmployeModel)db.Find(e => e.EmployeeID == id.Value).FirstOrDefault();
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeModel employee)
        {
            if (ModelState.IsValid)
            {
                db.Update((Employees)employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeModel employee = (EmployeModel)db.Find(e => e.EmployeeID == id.Value).FirstOrDefault();
            
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Delete((Employees) employee);
            return RedirectToAction("Index", new { page });
        }
    }
}