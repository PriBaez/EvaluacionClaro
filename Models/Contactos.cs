using System.ComponentModel.DataAnnotations;

namespace evaluacionClaro.Models
{
    public class Contactos
    {
        [Key]
        [Required]
        public int id { get; set; }

        [MaxLength(30, ErrorMessage = "Su nombre ha excedido la cantidad de caracteres permitidos")]
        [Required(ErrorMessage ="Debes introducir tu nombre para continuar.")]
        public string? Nombre { get; set; }

        [MaxLength(10, ErrorMessage = "Su telefono solo puede tener 10 digitos sin guiones")]
        [Required(ErrorMessage ="Debes introducir tu telefono para continuar.")]
        public string? Telefono { get; set; }

        [MaxLength(30, ErrorMessage = "Su correo ha excedido la cantidad de caracteres permitidos")]
        public string? Correo { get; set; }
    }
    
}

