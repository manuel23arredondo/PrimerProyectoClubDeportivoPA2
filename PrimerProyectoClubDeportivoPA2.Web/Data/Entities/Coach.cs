namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Coach : IEntity
    {
        [Display(Name = "No. de Coach")]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Matrícula")]

        public int EnrollmentNumber { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Nombre")]

        public string Name { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Apellidos")]

        public string LastName { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de fotografía")]

        public string UrlPicture { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(8, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Salario")]

        public double Salary { get; set; }

        
        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Antigüedad")]

        public string Antiquity { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de Curriculum Vitae")]

        public string UrlCV { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Horario de trabajo")]

        public string Schedule { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de Identificación Oficial")]

        public string UrlOfficialID { get; set; }

        public ICollection<TrainingSession> TrainingSessions { get; set; }
        public Facility Facility { get; set; }
        public Sport Sport { get; set; }
    }
}
