using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upload_Multiple_Files_HTML5.Controllers
{
public class HomeController : Controller
{
    // GET: Home
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(List<HttpPostedFileBase> postedFiles)
    {
        string path = Server.MapPath("~/Uploads/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        foreach (HttpPostedFileBase postedFile in postedFiles)
        {
            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
        }

        return View();
    }
}
}