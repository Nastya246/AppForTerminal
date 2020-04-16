using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AppTerminal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFile(string id)
        {
            var countFile = new DirectoryInfo(@"D:\terminal\AppTerminal\AppTerminal\Content\" + id).GetFiles().Count();
            var listFile = new List<string>();
            var listFileName = new List<string>();
            var getFile = new DirectoryInfo(@"D:\terminal\AppTerminal\AppTerminal\Content\" + id).GetFiles();
            //   Response.AppendHeader("Content-Disposition", "inline; filename=" + getFile[0].ToString() + ";");
            foreach (var file in getFile)
            {
                string path = file.FullName.Substring(35);
                listFile.Add(path);
                listFileName.Add(file.ToString());
            };
            ViewBag.listFile = listFile;
            ViewBag.listFileName = listFileName;
            //  var fileForOpen = getFile[0].FullName;
            //   var fileBytes = System.IO.File.ReadAllBytes(fileForOpen);
            //  return File(fileBytes, "application/pdf");      
            return View();
        }


    }
}