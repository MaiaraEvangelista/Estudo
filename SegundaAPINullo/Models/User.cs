using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 até 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 até 20 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 até 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 até 20 caracteres")]
        public string password { get; set; }

        public string Role { get; set; }
    }
}
