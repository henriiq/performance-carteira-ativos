using Microsoft.EntityFrameworkCore;
using PerformanceCarteiraAtivos.Infra.Contextos.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PerformanceCarteiraAtivos.Rentabilidade.Infra.Repositorios
{
    public class BaseRepository<TEntidade> : IDisposable
        where TEntidade : class
    {
        private readonly RentabilidadeContext _context;
        private readonly DbSet<TEntidade> _entidade;

        public BaseRepository()
        {
            _context = new RentabilidadeContext();
            _entidade = _context.Set<TEntidade>();
        }

        public void Adicionar(TEntidade entidade) => _context.Add(entidade);

        public TEntidade Obtem(Guid id) => _entidade.Find(id);

        public ICollection<TEntidade> Filtrar(Expression<Func<TEntidade, bool>> filtrar) =>
            _entidade.Where(filtrar).ToList();

        public ICollection<TEntidade> FiltrarAsNoTracking(Expression<Func<TEntidade, bool>> filtrar) =>
            _entidade.AsNoTracking().Where(filtrar).ToList();

        public void Salvar() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
