using System;
using NHibernate;
using NHibernateProject.Models;
using NHibernateProject;

class Program
{
    static void Main()
    {
        using (var session = NHibernateHelper.AbrirSessao())
        {
            using (var transaction = session.BeginTransaction())
            {
                var pessoa = new Pessoa { Nome = "João Silva", Idade = 30 };
                session.Save(pessoa);
                transaction.Commit();
            }

            var pessoas = session.Query<Pessoa>();

            foreach (var p in pessoas)
            {
                Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Idade: {p.Idade}");
            }
        }
    }
}
