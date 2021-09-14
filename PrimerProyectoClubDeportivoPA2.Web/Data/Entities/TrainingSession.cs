namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class TrainingSession
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Sesión de entrenamiento")]
        public string Name { get; set; }

        public Coach Coach { get; set; }
        public Member Member { get; set; }
    }
}
