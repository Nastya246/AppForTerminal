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
            var path = "";
            var countFile = new DirectoryInfo(@"D:\AppForTerminal\AppTerminal\AppTerminal\Content\" + id).GetFiles().Count();
            var listFile = new List<string>();
            var listFileName = new List<string>();
            var flagPath = false;
            var getFile = new DirectoryInfo(@"D:\AppForTerminal\AppTerminal\AppTerminal\Content\" + id).GetFiles();
            //   Response.AppendHeader("Content-Disposition", "inline; filename=" + getFile[0].ToString() + ";");
            foreach (var file in getFile)
            {
                string[] stringTempList = (file.FullName).Split('\\');
                var resulttemp = stringTempList.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                stringTempList = resulttemp;
                foreach(var str in stringTempList)
                {
                    if (flagPath)
                    {
                        path += "\\"+str;
                    }
                    if (str=="Content")
                    {
                        path += "\\" + str;
                        flagPath = true;
                    }
                }
               
              //  string path = file.FullName.Substring(41);
                listFile.Add(path);
                listFileName.Add(file.ToString());
                flagPath = false;
                path = "";
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