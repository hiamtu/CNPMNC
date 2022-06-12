using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;
using PagedList;
using PagedList.Mvc;

namespace CNPMNC.Controllers
{
    public class CTDONHANGController : Controller
    {
        private QuanLiGHEntities db = new QuanLiGHEntities();

        // GET: CTDONHANG
        public ActionResult Index(int? page, string search)
        {
            int pageSize = 25;
            int pageNum = (page ?? 1);
            
            if (search != null)
            {
                var productList = db.CTDONHANGs.Include(c => c.DONHANG).Include(c => c.SHIPPER).Include(c => c.PHI).Where(s => s.Mota.Contains(search)).OrderByDescending(x => x.Mota);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            var cTDONHANGs = db.CTDONHANGs.Include(c => c.DONHANG).Include(c => c.SHIPPER).Include(c => c.PHI).OrderByDescending(x=>x.IDCTDONHANG);
            return View(cTDONHANGs.ToPagedList(pageNum, pageSize));

        }

        // GET: CTDONHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONHANG cTDONHANG = db.CTDONHANGs.Find(id);
            if (cTDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDONHANG);
        }

        // GET: CTDONHANG/Create
        public ActionResult Create()
        {
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi");
            ViewBag.IDShipper = new SelectList(db.SHIPPERs, "IDShipper", "TenShipper");
            ViewBag.PhiShip = new SelectList(db.PHIs, "IDPhi", "IDDonHang");
            return View();
        }

        // POST: CTDONHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDonHang,IDShipper,Mota,IDCTDONHANG,PhiShip,DONGIA")] CTDONHANG cTDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.CTDONHANGs.Add(cTDONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", cTDONHANG.IDDonHang);
            ViewBag.IDShipper = new SelectList(db.SHIPPERs, "IDShipper", "TenShipper", cTDONHANG.IDShipper);
            ViewBag.PhiShip = new SelectList(db.PHIs, "IDPhi", "IDDonHang", cTDONHANG.PhiShip);
            return View(cTDONHANG);
        }

        // GET: CTDONHANG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONHANG cTDONHANG = db.CTDONHANGs.Find(id);
            if (cTDONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", cTDONHANG.IDDonHang);
            ViewBag.IDShipper = new SelectList(db.SHIPPERs, "IDShipper", "TenShipper", cTDONHANG.IDShipper);
            ViewBag.PhiShip = new SelectList(db.PHIs, "IDPhi", "IDDonHang", cTDONHANG.PhiShip);
            return View(cTDONHANG);
        }

        // POST: CTDONHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDonHang,IDShipper,Mota,IDCTDONHANG,PhiShip,DONGIA")] CTDONHANG cTDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDonHang = new SelectList(db.DONHANGs, "IDDonHang", "NoiDi", cTDONHANG.IDDonHang);
            ViewBag.IDShipper = new SelectList(db.SHIPPERs, "IDShipper", "TenShipper", cTDONHANG.IDShipper);
            ViewBag.PhiShip = new SelectList(db.PHIs, "IDPhi", "IDDonHang", cTDONHANG.PhiShip);
            return View(cTDONHANG);
        }

        // GET: CTDONHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONHANG cTDONHANG = db.CTDONHANGs.Find(id);
            if (cTDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDONHANG);
        }

        // POST: CTDONHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTDONHANG cTDONHANG = db.CTDONHANGs.Find(id);
            db.CTDONHANGs.Remove(cTDONHANG);
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
