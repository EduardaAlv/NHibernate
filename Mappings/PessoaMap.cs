using FluentNHibernate.Mapping;
using NHibernateProject.Models;

namespace NHibernateProject.Mappings
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoas");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Idade);
        }
    }
}
