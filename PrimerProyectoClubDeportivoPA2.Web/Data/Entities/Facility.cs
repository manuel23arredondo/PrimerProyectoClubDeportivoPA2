namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Facility : IEntity
    {
        [Display(Name = "No. de Instalación")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Clave")]

        public string Code { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Nombre de Instalación")]

        public string Name { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(40, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Descripción")]

        public string Description { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de fotografía")]

        public string UrlPicture { get; set; }
    }
}
