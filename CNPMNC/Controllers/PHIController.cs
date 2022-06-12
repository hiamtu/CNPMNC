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
    public class PHIController : Controller
    {
        private QuanLiGHEntities db = new QuanLiGHEntities();

        // GET: PHI
        public ActionResult Index()
        {
            var pHIs = db.PHIs.Include(p => p.DONHANG);
            return View(pHIs.ToList());
        }

        // GET: PHI/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHI pHI = db.PHIs.Find(id);
            if (pHI == null)
            {
                return HttpNotFound();
            }
            return View(pHI);
        }

        // GET: PHI/Create
        public ActionResult Create()
        {
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi");
            return View();
        }

        // POST: PHI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhi,IDDonHang,Gia,QuangDuong")] PHI pHI)
        {
            if (ModelState.IsValid)
            {
                db.PHIs.Add(pHI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", pHI.IDDonHang);
            return View(pHI);
        }

        // GET: PHI/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHI pHI = db.PHIs.Find(id);
            if (pHI == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", pHI.IDDonHang);
            return View(pHI);
        }

        // POST: PHI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhi,IDDonHang,Gia,QuangDuong")] PHI pHI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", pHI.IDDonHang);
            return View(pHI);
        }

        // GET: PHI/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHI pHI = db.PHIs.Find(id);
            if (pHI == null)
            {
                return HttpNotFound();
            }
            return View(pHI);
        }

        // POST: PHI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHI pHI = db.PHIs.Find(id);
            db.PHIs.Remove(pHI);
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
