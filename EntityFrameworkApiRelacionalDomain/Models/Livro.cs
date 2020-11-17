using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacional.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Titulo")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Entre 01 e 100 Caracteres")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Decimal? Valor { get; set; }

        public Autor Autor { get; }
    }
}
