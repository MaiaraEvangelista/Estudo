using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo.Models
{
    public class Category
    {

        //Gera uma tabela categoria
        // [Table("Categoria")]
        [Key]
        public int Id { get; set; }
        //[DataType("")] = define o tipo de dado
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter de 3 à 60 caràcteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 à 60 carácteres!")]
        public string Title { get; set; }

    }
}
