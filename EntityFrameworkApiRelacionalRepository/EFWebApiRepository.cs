using EntityFrameworkApiRelacional.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacionalRepository
{
    public class EFWebApiRepository : IEFWebApiRepository
    {
        private readonly DataLivrosContext _context;

        public EFWebApiRepository(DataLivrosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //===============================================================================

        public Task<Autor[]> GetAutors()
        {
            IQueryable<Autor> query = _context.Autors
                 .Include(a => a.Livros);

            query = query.AsNoTracking()
                .OrderBy(a => a.Nome);

            return query.ToArrayAsync();
        }

        public Task<Autor> GetAutorId(int AutorId)
        {
            IQueryable<Autor> query = _context.Autors
                 .Include(a => a.Livros);

            query = query.AsNoTracking()
                .OrderByDescending(a => a.Nome)
                .Where(a => a.AutorId == AutorId);

            return query.FirstOrDefaultAsync();
        }          

        public Task<Livro[]> GetLivro()
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.AsNoTracking()
                .OrderBy(l => l.Titulo);

            return query.ToArrayAsync();
        }

        public Task<Livro> GetLivroId(int LivroId)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.AsNoTracking()
                .OrderByDescending(l => l.Titulo)
                .Where(l => l.LivroId == LivroId);

            return query.FirstOrDefaultAsync();
        }
    }
}
