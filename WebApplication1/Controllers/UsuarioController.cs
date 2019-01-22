using BusinessRules.Impl;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Teste()
        {
            return View();
        }

        public ActionResult TestAddUser()
        {
            Usuario user = new Usuario();
            user.UserName = "Admin";
            user.Senha = "admin";
            user.IsAdm = true;
            usuarioBusiness.Add(user);
            Usuario user2 = new Usuario();
            user2.UserName = "AndreRibeiro";
            user2.Senha = "sorvetegostoso";
            user2.IsAdm = false;
            usuarioBusiness.Add(user2);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string userName, string senha, string returnUrl)
        {
            Usuario user = await usuarioBusiness.Login(userName, senha);
            if (user == null)
            {
                ViewBag.Erro = "Usuário e/ou senha inválidos";
                return View();
            }
            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddYears(1), true, user.ID + "," + user.IsAdm);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie("putsCookie", encryptedTicket);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Profissional");
            }
            return Redirect(returnUrl);
        }

    }
}