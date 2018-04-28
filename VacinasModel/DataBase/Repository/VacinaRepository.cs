using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacinasModel.DataBase.Model;

namespace VacinasModel.DataBase.Repository
{
    public class VacinaRepository : RepositoryBase<Vacina>
    {
        public VacinaRepository(ISession session) : base(session)
        {

        }
        public IList<Vacina> FindAll(Guid idCartaoVacina)
        {
            var avaliacao = this.Session.Query<Vacina>().Where(p => p.CartaoVacina.IdCartaoVacina == idCartaoVacina)
              .ToList();

            return avaliacao;
        }
        public IList<Vacina> BuscarPorNome(String nome, Guid idCartaoVacina)
        {
            var buscaAux = this.Session.Query<Vacina>().Where(p => p.CartaoVacina.IdCartaoVacina == idCartaoVacina)
              .ToList();
            return buscaAux.Where(w => w.Nome.ToLower() == nome.Trim().ToLower()).ToList();
        }

    }
}
