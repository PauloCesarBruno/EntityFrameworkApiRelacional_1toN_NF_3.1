using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacional.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }

        public ICollection <Livro> Livros { get; set; }
    }
}
