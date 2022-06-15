using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bitcoin.Models;

namespace Bitcoin.Controllers
{
    public class BituserController : Controller
    {
        private MyContext db = new MyContext();

        public ActionResult Logout()
        {
            Session.Remove("type");
            return Redirect("/Home/Login");
        }


        // GET: Bituser
        public ActionResult Index()
        {
            return View(db.Bitusers.ToList());
        }

        // GET: Bituser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bituser bituser = db.Bitusers.Find(id);
            if (bituser == null)
            {
                return HttpNotFound();
            }
            return View(bituser);
        }

        // GET: Bituser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bituser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,AboutMe,Package")] Bituser bituser)
        {
            if (ModelState.IsValid)
            {
                db.Bitusers.Add(bituser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bituser);
        }

        // GET: Bituser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bituser bituser = db.Bitusers.Find(id);
            if (bituser == null)
            {
                return HttpNotFound();
            }
            return View(bituser);
        }

        // POST: Bituser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,AboutMe,Package")] Bituser bituser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bituser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bituser);
        }

        // GET: Bituser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bituser bituser = db.Bitusers.Find(id);
            if (bituser == null)
            {
                return HttpNotFound();
            }
            return View(bituser);
        }

        // POST: Bituser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bituser bituser = db.Bitusers.Find(id);
            db.Bitusers.Remove(bituser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
