using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BJAT.Services.Contracts;

namespace BJAT.Web.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            var content = new StreamReader(file.InputStream).ReadToEnd();
            _analysisService.ImportDataFromFile(content, User.Identity.Name);
            return RedirectToAction("Index");
        }
    }
}