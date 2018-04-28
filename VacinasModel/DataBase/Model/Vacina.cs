using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacinasModel.DataBase.Model
{
    public class Vacina
    {
        public virtual Guid IdVacina { get; set; }
        public virtual CartaoVacina CartaoVacina { get; set; }
        public virtual DateTime DtVacina { get; set; }
        public virtual String Nome { get; set; }
        public virtual DateTime DtValidade { get; set; }

        public class VacinasMap : ClassMapping<Vacina>
        {
            public VacinasMap()
            {
                Id(x => x.IdVacina, m => m.Generator(Generators.Guid));
                //conferir se relação está certa
                ManyToOne(x => x.CartaoVacina, m =>
                {
                    m.Column("IdCartaoVacina");
                    m.Lazy(LazyRelation.NoLazy);
                });

                Property(x => x.DtVacina);

                Property(x => x.Nome);
                Property(x => x.DtValidade);
            }

        }
    }
}
