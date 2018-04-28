using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacinasModel.DataBase;
using VacinasModel.DataBase.Model;
using VacinasModel.DataBase.Utils;

namespace Vacinas.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult CadastrarUsuario()
        {
            return View(new Usuario());
        }

        public ActionResult EntrarUsuario()
        {
            return View();
        }

        public ActionResult Logar(string usuario, string senha)
        {
            LoginUtils.Logar(usuario, senha);

            if (LoginUtils.Usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("EntrarUsuario");
            }
        }

        public ActionResult DeslogarUsuario()
        {
            LoginUtils.Deslogar();
            return RedirectToAction("EntrarUsuario");
        }
        public ActionResult GravarUsuario(Usuario usuario)
        {
        
            DbFactory.Instance.UsuarioRepository.SaveOrUpdate(usuario);
            var cartao = new CartaoVacina()
            {
                DtCartao = DateTime.Now,             
                Usuario = usuario

            };
            DbFactory.Instance.CartaoVacinaRepository.SaveOrUpdate(cartao);

            return RedirectToAction("EntrarUsuario");


        }



    }
}