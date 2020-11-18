using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacional.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name ="Nome")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Entre 03 e 100 Caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Campo Até 100 Caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email com formato Incorreto !")]
        public String Email { get; set; }

        public ICollection <Livro> Livros { get; set; }
    }
}