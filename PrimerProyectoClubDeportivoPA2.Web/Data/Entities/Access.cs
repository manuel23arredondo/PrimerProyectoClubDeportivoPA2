namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Access
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Acceso")]
        public string Name { get; set; }

        public Facility Facilty { get; set; }
    }
}
