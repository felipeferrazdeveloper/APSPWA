using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacinasModel.DataBase.Model;

namespace VacinasModel.DataBase.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(ISession session) : base(session)
        {

        }
        public Usuario Login(String login, String senha)
        {
            try
            {
                return this.Session.Query<Usuario>().FirstOrDefault(f => f.CartaoSUS == login && f.Senha == senha);
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario não encontrado", ex);
            }
        }
    }
}
