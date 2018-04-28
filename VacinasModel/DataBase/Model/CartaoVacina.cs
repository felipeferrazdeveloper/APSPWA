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
    public class CartaoVacina
    {
        public virtual Guid IdCartaoVacina { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual DateTime DtCartao { get; set; }
        public virtual IList<Vacina> ListVacinas { get; set; }



        public class CartaoVacinaMap : ClassMapping<CartaoVacina>
        {
            public CartaoVacinaMap()
            {
                Id(x => x.IdCartaoVacina, m => m.Generator(Generators.Guid));
                ManyToOne(x => x.Usuario, m =>
                {
                    m.Column("IdUsuario");
                    m.Unique(true);
                    m.NotNullable(true);
                    m.Lazy(LazyRelation.NoLazy);
                });


                Property(x => x.DtCartao);
                //conferir relação
                Bag<Vacina>(x => x.ListVacinas, m =>
                {
                    m.Cascade(Cascade.All);
                    m.Key(k => k.Column("IdCartaoVacina"));
                    m.Lazy(CollectionLazy.NoLazy);
                    m.Inverse(true);
                },
                r => r.OneToMany());
            }
        }
    }
}
