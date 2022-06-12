using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Controllers
{
    public class SHIPPERController : Controller
    {
        private QuanLiGHEntities db = new QuanLiGHEntities();

        // GET: SHIPPER
        public ActionResult Index()
        {
            return View(db.SHIPPERs.ToList());
        }

        // GET: SHIPPER/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIPPER sHIPPER = db.SHIPPERs.Find(id);
            if (sHIPPER == null)
            {
                return HttpNotFound();
            }
            return View(sHIPPER);
        }

        // GET: SHIPPER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SHIPPER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDShipper,TenShipper,SDT,DiaChi,CMND")] SHIPPER sHIPPER)
        {
            if (ModelState.IsValid)
            {
                db.SHIPPERs.Add(sHIPPER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHIPPER);
        }

        // GET: SHIPPER/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIPPER sHIPPER = db.SHIPPERs.Find(id);
            if (sHIPPER == null)
            {
                return HttpNotFound();
            }
            return View(sHIPPER);
        }

        // POST: SHIPPER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDShipper,TenShipper,SDT,DiaChi,CMND")] SHIPPER sHIPPER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHIPPER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHIPPER);
        }

        // GET: SHIPPER/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHIPPER sHIPPER = db.SHIPPERs.Find(id);
            if (sHIPPER == null)
            {
                return HttpNotFound();
            }
            return View(sHIPPER);
        }

        // POST: SHIPPER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SHIPPER sHIPPER = db.SHIPPERs.Find(id);
            db.SHIPPERs.Remove(sHIPPER);
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
