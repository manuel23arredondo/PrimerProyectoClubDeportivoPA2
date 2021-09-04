namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Guest : IEntity
    {
        [Display(Name = "Número de Interesado")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(35, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Correo")]

        public string Email { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Nombre")]

        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Apellidos")]

        public string LastName { get; set; }
    }
}
