using System;

namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Member:IEntity
    {
        [Display(Name = "No. de Miembro")]
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Matrícula")]

        public int MembershipNumber { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Nombre")]

        public string Name { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Apellidos")]

        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Fecha de Nacimiento")]

        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de fotografía")]

        public string UrlPicture { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Salario")]

        public int CellphoneNumber { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(35, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Correo")]

        public string Email { get; set; }


        [Required(ErrorMessage = "{0} es obligatorio.")]

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        [Display(Name = "Url de Identificación Oficial")]

        public string UrlOfficialID { get; set; }
    }
}
