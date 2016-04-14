using CFApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFApp.Controllers
{
    public class HomeController : Controller
    {
        CFTestContext _context = new CFTestContext();

        public ActionResult Index(string sortOrder, string searchString) // get all elements in db 
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in _context.TestEntities
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Surname.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "No":
                    students = students.OrderBy(s => s.No);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.No);
                    break;
                default:
                    students = students.OrderBy(s => s.Surname);
                    break;
            }

            return View(students.ToList());
           // return View(_context.TestEntities.ToList());
        }


      
        public ActionResult Create(TestEntity tstenty)
        {
            if (ModelState.IsValid)
            {
                _context.TestEntities.Add(tstenty);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstenty);
        }


        public ActionResult Delete(int id = 0) {
            TestEntity test = _context.TestEntities.Find(id);  // o id ye ait nesneyi bulduk 
            if (test == null) {
                return HttpNotFound();
            }
           _context.TestEntities.Remove(test); // delete obje from db 
            _context.SaveChanges(); // save changes
            return RedirectToAction("Index"); // turn to index view
        }

        public ActionResult Update(TestEntity testentity ) {

            if(ModelState.IsValid){
                _context.Entry(testentity).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testentity);
        }

        public ActionResult Details(int id = 0)
        {
            TestEntity testentity = _context.TestEntities.Find(id);
            if (testentity == null)
            {
                return HttpNotFound();
            }
            return View(testentity);
        }

        public ActionResult Research(string lookfor) {

            var models = from s in _context.TestEntities
                           select s;
            if (!String.IsNullOrEmpty(lookfor))
            {
                models = models.Where(s => s.Name.ToUpper().Contains(lookfor.ToUpper())
                                       || s.Surname.ToUpper().Contains(lookfor.ToUpper()));
            }
            return View(models.ToList());
            /*var models = from s in _context.TestEntities
                        select s;

            if(!String.IsNullOrEmpty(lookfor)){
                models = models.Where(s => s.Surname.Contains(lookfor) || s.No.Contains(lookfor));
            }
        
            return View(models.ToList()); // bulduklarının listesini dönüyor*/
        }

    }
}
