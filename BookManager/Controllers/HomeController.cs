using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null || file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);

                string path = Path.Combine(Server.MapPath("/images/"), _FileName);
                if (System.IO.File.Exists(path)) 
                {
                    //nếu hình ảnh đã tồn tại, thì xóa ảnh cũ, cập nhật lại ảnh mới
                    System.IO.File.Delete(path);
                    file.SaveAs(path);
                }
                else
                {
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadMultipleImage(HttpPostedFileBase[] files)
        {
            foreach (HttpPostedFileBase file in files)
            {
                if (file != null || file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);

                    string path = Path.Combine(Server.MapPath("/images/"), _FileName);
                    if (System.IO.File.Exists(path))
                    {
                        //nếu hình ảnh đã tồn tại, thì xóa ảnh cũ, cập nhật lại ảnh mới
                        System.IO.File.Delete(path);
                        file.SaveAs(path);
                    }
                    else
                    {
                        file.SaveAs(path);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}