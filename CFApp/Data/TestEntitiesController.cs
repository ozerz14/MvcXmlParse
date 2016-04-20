using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFApp.Data
{
    public class TestEntitiesController : Controller
    {
        private CFTestContext db = new CFTestContext();

        //
        // GET: /TestEntities/

        public ActionResult Index()
        {
            return View(db.TestEntities.ToList());
        }

        //
        // GET: /TestEntities/Details/5

        public ActionResult Details(int id = 0)
        {
            TestEntity testentity = db.TestEntities.Find(id);
            if (testentity == null)
            {
                return HttpNotFound();
            }
            return View(testentity);
        }

        //
        // GET: /TestEntities/Create

        public ActionResult Create()
        {
            ViewModelEntity vment = new ViewModelEntity();
            vment.control = true;
            return View(vment);
        }


        [HttpPost]
        public ActionResult Create(ViewModelEntity testentity)
        {
            if (ModelState.IsValid)
            {
                TestEntity tst = new TestEntity
                 {
                     Name= testentity.Name,
                     No= testentity.control ? 1:0, 
                     Surname=""
                 };
                return View(tst);
            }
         return RedirectToAction("Index", "Home");
        }
        //
      /*  // POST: /TestEntities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestEntity testentity)
        {
            if (ModelState.IsValid)
            {
                db.TestEntities.Add(testentity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testentity);
        }
        */
        //
        // GET: /TestEntities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TestEntity testentity = db.TestEntities.Find(id);
            if (testentity == null)
            {
                return HttpNotFound();
            }
            return View(testentity);
        }

        //
        // POST: /TestEntities/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestEntity testentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testentity);
        }

        //
        // GET: /TestEntities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TestEntity testentity = db.TestEntities.Find(id);
            if (testentity == null)
            {
                return HttpNotFound();
            }
            return View(testentity);
        }

        //
        // POST: /TestEntities/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestEntity testentity = db.TestEntities.Find(id);
            db.TestEntities.Remove(testentity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}