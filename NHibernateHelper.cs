using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateProject.Models;
using System;

namespace NHibernateProject
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CriarSessionFactory()
        {
            if (_sessionFactory != null)
                return _sessionFactory;

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=DESKTOP-ILHUQ20;Initial Catalog=teste;Trusted_Connection=True;TrustServerCertificate=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pessoa>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true)) // Cria o schema no banco
                .BuildSessionFactory();

            return _sessionFactory;
        }

        public static ISession AbrirSessao() => CriarSessionFactory().OpenSession();
    }
}
