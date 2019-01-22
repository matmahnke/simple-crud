using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Security;
using WebApplication1.WEB;

namespace WebApplication1.Controllers
{
    public class ProfissionalController : Controller
    {
        private ILog logger;

        public ProfissionalController(ILog log)
        {
            this.logger = log;
        }

        // GET: Profissional
        public ActionResult Index()
        {
            return View();
        }
        [Authorize] 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(ProfissionalCustomModelBinder))] ProfissionalViewModel profissionalViewModel)
        {
            return View();
        }
    }
}