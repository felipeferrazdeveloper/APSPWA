using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacinasModel.DataBase.Model;

namespace VacinasModel.DataBase.Repository
{
    public class CartaoVacinaRepository : RepositoryBase<CartaoVacina>
    {
        public CartaoVacinaRepository(ISession session) : base(session)
        {
        }
        public CartaoVacina FirstCard(Guid idCartaoVacina)
        {
            var cartao = this.Session.Query<CartaoVacina>().FirstOrDefault(f => f.IdCartaoVacina == idCartaoVacina);

            return cartao;
        }
    }
}
