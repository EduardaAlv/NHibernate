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
                var pessoa = new Pessoa { Nome = "Eduarda Portes", Idade = 23 };
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

    public void Adicionar(Pessoa pessoa)
    {
        using (var session = NHibernateHelper.AbrirSessao())
        using (var transaction = session.BeginTransaction())
        {
            session.Save(pessoa);
            transaction.Commit();
        }
    }

    public Pessoa BuscarPorId(int id)
    {
        using (var session = NHibernateHelper.AbrirSessao())
        {
            return session.Get<Pessoa>(id);
        }
    }

    public IList<Pessoa> ListarTodos()
    {
        using (var session = NHibernateHelper.AbrirSessao())
        {
            return session.Query<Pessoa>().ToList().Where(n => n.Nome == "Eduarda Portes").ToList();
        }
    }

    public void Atualizar(Pessoa pessoa)
    {
        using (var session = NHibernateHelper.AbrirSessao())
        using (var transaction = session.BeginTransaction())
        {
            session.Update(pessoa);
            transaction.Commit();
        }
    }

    public void Deletar(int id)
    {
        using (var session = NHibernateHelper.AbrirSessao())
        using (var transaction = session.BeginTransaction())
        {
            var pessoa = session.Get<Pessoa>(id);
            if (pessoa != null)
            {
                session.Delete(pessoa);
                transaction.Commit();
            }
        }
    }
}
