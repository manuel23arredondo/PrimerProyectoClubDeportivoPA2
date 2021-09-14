namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PermissionAccess : IEntity
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Permiso para acceder")]
        public string Name { get; set; }

        public Sport Sport { get; set; }
    }
}
