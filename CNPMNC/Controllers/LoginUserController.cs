using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMNC.Controllers
{
    public class LoginUserController : Controller
    {
        QuanLiGHEntities database = new QuanLiGHEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(TAIKHOAN _user)
        {
            var check = database.TAIKHOANs.
                Where(s => s.TenTaiKhoan == _user.TenTaiKhoan && s.MatKhau == _user.MatKhau).FirstOrDefault();

            if (check == null)//sai thong tin
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index", _user);
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                //Session["TenTaiKhoan"] = _user.TenTaiKhoan;
                return RedirectToAction("Index", "DONHANG");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TAIKHOAN _user)
        {
            if (ModelState.IsValid)
            {
                var check_id = database.TAIKHOANs.FirstOrDefault(s => s.IDTaiKhoan == _user.IDTaiKhoan);
                if (check_id == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.TAIKHOANs.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index", "LoginUser");
                }
                else
                {
                    ViewBag.ErrorRegister = "ID already exists";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}