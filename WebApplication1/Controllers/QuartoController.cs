using BusinessRules;
using BusinessRules.Impl;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Security;
using WebApplication1.WEB;
using WebApplication1.WEB.Extensions;

namespace WebApplication1.Controllers
{
    public class QuartoController : BaseAuthorizationController
    {
        private QuartoBusiness businessQuarto = new QuartoBusiness();

        public QuartoController(MvcUser user):base(user)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            IList<Quarto> quartos = businessQuarto.GetAll();
            return View(CustomAutoMapper<QuartoViewModel, Quarto>.Map(quartos));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuartoViewModel quartoViewModel)
        {
            Quarto quarto =
            CustomAutoMapper<Quarto, QuartoViewModel>.Map(quartoViewModel);
            try
            {
                businessQuarto.Add(quarto);
                return RedirectToAction("Index");
            }
            catch (PutsException ex)
            {
                ModelState.BindingErrors(ex);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Quarto quarto = businessQuarto.GetByID(id.Value);
            if (quarto == null)
            {
                return RedirectToAction("Index");
            }
            QuartoViewModel viewModel =
                CustomAutoMapper<QuartoViewModel, Quarto>.Map(quarto);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(QuartoViewModel quartoViewModel)
        {
            Quarto quarto =
            CustomAutoMapper<Quarto, QuartoViewModel>.Map(quartoViewModel);
            try
            {
                businessQuarto.Edit(quarto);
                return RedirectToAction("Index");
            }
            catch (PutsException ex)
            {
                ModelState.BindingErrors(ex);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(QuartoViewModel quartoViewModel)
        {
            Quarto quarto =
            CustomAutoMapper<Quarto, QuartoViewModel>.Map(quartoViewModel);
            try
            {
                businessQuarto.Delete(quarto);
                return Json(new { Message = "Excluído com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            catch (PutsException ex)
            {
                return Json(new { Message = "Erro na exclusão" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}