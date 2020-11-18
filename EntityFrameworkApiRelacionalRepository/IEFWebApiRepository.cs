using EntityFrameworkApiRelacional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacionalRepository
{
    public interface IEFWebApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();

        //======================================================================

        Task<Autor[]> GetAutors();
        Task<Autor> GetAutorId(int AutorId);

        Task<Livro[]> GetLivro();
        Task<Livro> GetLivroId(int LivroId);
    }
}