using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EX3.Controllers
{
    public class UpploadFileController : Controller
    {
        // GET: UpploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var docFile = Request.Files["document"];
            if (docFile != null && docFile.ContentLength > 0)
            {
                var path = Server.MapPath("~/UploadFiles/") + docFile.FileName;
                docFile.SaveAs(path);
                ViewBag.DocFileName = docFile.FileName;
                ViewBag.DocFileType = docFile.ContentType;
                ViewBag.DocFileSize = docFile.ContentLength;
            }
            var imageFile = Request.Files["image"];
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                var path = Server.MapPath("~/Images/") + imageFile.FileName;
                imageFile.SaveAs(path);
                ViewBag.ImageFileName = imageFile.FileName;
            }
            return View();
        }
    }
}