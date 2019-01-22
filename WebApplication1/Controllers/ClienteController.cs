using BusinessRules;
using BusinessRules.Impl;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Security;
using WebApplication1.WEB;
using WebApplication1.WEB.Extensions;

namespace WebApplication1.Controllers
{
    public class ClienteController : BaseAuthorizationController
    {
        private ClienteBusiness businessCliente = new ClienteBusiness();

        public ClienteController(MvcUser user):base(user)
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            IList<Cliente> clientes = businessCliente.GetAll();
            return View(CustomAutoMapper<ClienteViewModel, Cliente>.Map(clientes));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel quartoViewModel)
        {
            Cliente cliente =
            CustomAutoMapper<Cliente, ClienteViewModel>.Map(quartoViewModel);
            try
            {
                businessCliente.Add(cliente);
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
            Cliente quarto = businessCliente.GetByID(id.Value);
            if (quarto == null)
            {
                return RedirectToAction("Index");
            }
            ClienteViewModel viewModel =
                CustomAutoMapper<ClienteViewModel, Cliente>.Map(quarto);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ClienteViewModel quartoViewModel)
        {
            Cliente quarto =
            CustomAutoMapper<Cliente, ClienteViewModel>.Map(quartoViewModel);
            try
            {
                businessCliente.Edit(quarto);
                return RedirectToAction("Index");
            }
            catch (PutsException ex)
            {
                ModelState.BindingErrors(ex);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ClienteViewModel quartoViewModel)
        {
            Cliente quarto =
            CustomAutoMapper<Cliente, ClienteViewModel>.Map(quartoViewModel);
            try
            {
                businessCliente.Delete(quarto);
                return Json(new { Message = "Excluído com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            catch (PutsException ex)
            {
                return Json(new { Message = "Erro na exclusão" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}