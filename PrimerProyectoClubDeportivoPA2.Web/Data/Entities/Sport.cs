using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Sport:IEntity
    {
        [Display(Name = "No. de Deporte")]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Deporte")]

        public string Name { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(40, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Descripción")]

        public string Description { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Horario de trabajo")]

        public string Schedule { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Días de clase")]

        public string ClassDay { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(3, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Cupo")]

        public int Capacity { get; set; }
    }
}
