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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (LoginUtils.Usuario != null)
            {
                var vacinas = DbFactory.Instance.VacinaRepository.FindAll(LoginUtils.Usuario.CartaoVacina.IdCartaoVacina);

                return View(vacinas);
            }
            else
            {
                return RedirectToAction("EntrarUsuario", "Usuario");
            }
        }

        public ActionResult CreateVacina()
        {
            var vacina = new Vacina();
            return View(vacina);
        }

        public ActionResult GravarVacina(Vacina vacina)
        {
            var user = LoginUtils.Usuario;

            var cartao = DbFactory.Instance.CartaoVacinaRepository.FirstCard(user.CartaoVacina.IdCartaoVacina);

            vacina.CartaoVacina = cartao;
            try
            {
                DbFactory.Instance.VacinaRepository.SaveOrUpdate(vacina);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");

        }

        public ActionResult DeleteVacina(Guid idVacina)
        {
            var vacina = DbFactory.Instance.VacinaRepository.FindAll().FirstOrDefault(f => f.IdVacina == idVacina);

            DbFactory.Instance.VacinaRepository.Delete(vacina);

            return RedirectToAction("Index");
        }

        public ActionResult Buscar(String edtBusca)
        {
            if (String.IsNullOrEmpty(edtBusca))
            {
                return RedirectToAction("Index");
            }

            var produto = DbFactory.Instance.VacinaRepository.BuscarPorNome(edtBusca, LoginUtils.Usuario.CartaoVacina.IdCartaoVacina);

            return View("Index", produto);
        }

    }
}