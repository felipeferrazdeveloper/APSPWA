using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacinasModel.DataBase.Model
{
    public class Usuario
    {
        public virtual Guid IdUsuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual String CartaoSUS { get; set; }
        public virtual CartaoVacina CartaoVacina { get; set; }
      
        

        public Usuario()
        {
         
        }

        public class UsuarioMap : ClassMapping<Usuario>
        {
            public UsuarioMap()
            {
                //esta mapeando uma primarykey
                Id(x => x.IdUsuario, m => m.Generator(Generators.Guid));


                Property(x => x.Senha);
                Property(x => x.Nome);
                Property(x => x.DtNascimento);
                Property(x => x.CartaoSUS);
                OneToOne(x => x.CartaoVacina,
                map =>
                     {           
                        map.PropertyReference(typeof(CartaoVacina).GetProperty("Usuario"));
                        map.Cascade(Cascade.All);
                        map.Lazy(LazyRelation.NoLazy);


                      });




            }
        }
    }
}
