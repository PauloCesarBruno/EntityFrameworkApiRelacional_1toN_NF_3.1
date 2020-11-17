using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacional.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public String Titulo { get; set; }
        public Decimal? Valor { get; set; }

        public Autor Autor { get; }
    }
}
