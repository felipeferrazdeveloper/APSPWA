using System.Web;
using VacinasModel.DataBase.Model;

namespace VacinasModel.DataBase.Utils
{
    public class LoginUtils
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    return (Usuario)HttpContext.Current.Session["Usuario"];
                }

                return null;
            }
        }

        public static void Logar(string login, string senha)
        {
            var usuario = DbFactory.Instance.UsuarioRepository.Login(login, senha);
            if (usuario != null)
            {
                HttpContext.Current.Session["Usuario"] = usuario;
            }

        }

        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}
