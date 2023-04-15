using ReviewFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewFood.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        dbReviewFoodDataContext db = new dbReviewFoodDataContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var all_key = from r in db.Posts select r;
            return View(all_key);
        }
        public ActionResult Delete(int id)
        {
            var all_del = db.Posts.First(m => m.PostID == id);
            return View(all_del);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Post s)
        {
            var E_ID = Convert.ToInt32(collection["PostID"]);
            var E_tieude = collection["tieude"];
            var E_hinh = collection["hinh"];
            var E_ngaytailen = Convert.ToDateTime(collection["ngaytailen"]);
            var E_nd = collection["noidung"];
            var E_islike = Convert.ToBoolean(collection["islikep"]); //bit nen convert ve boolean
            var E_CmtID = collection["CommentID"]; //vi la long nen convert ve string

            if (string.IsNullOrEmpty(E_tieude))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.PostID = E_ID;
                s.tieude = E_tieude;
                s.CommentID = E_CmtID.LongCount();
                s.hinh = E_hinh.ToString();
                s.ngaytailen = E_ngaytailen;
                s.noidung = E_nd;
                s.islikep = E_islike;
                db.Posts.InsertOnSubmit(s);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
    }
}