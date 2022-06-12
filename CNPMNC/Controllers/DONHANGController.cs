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
    public class DONHANGController : Controller
    {
        private QuanLiGHEntities db = new QuanLiGHEntities();

        // GET: DONHANG
        public ActionResult Index(int ?page,string search)
        {
            int pageSize = 25;
            int pageNum = (page ?? 1);
            if (search != null)
            {
                var productList = db.DONHANGs.Where(s => s.NoiDi.Contains(search)).OrderByDescending(x => x.NoiDi);
                return View(productList.ToPagedList(pageNum, pageSize));

            }
            var donhangList = db.DONHANGs.OrderByDescending(x => x.IDDonHang);
            return View(donhangList.ToPagedList(pageNum,pageSize));
        }

        // GET: DONHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: DONHANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DONHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDonHang,NoiDi,NoiDen,CanNang,HinhThucVanChuyen,TrangThai,Ngay,DonGia")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGs.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dONHANG);
        }

        // GET: DONHANG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: DONHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDonHang,NoiDi,NoiDen,CanNang,HinhThucVanChuyen,TrangThai,Ngay,DonGia")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dONHANG);
        }

        // GET: DONHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: DONHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(dONHANG);
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
