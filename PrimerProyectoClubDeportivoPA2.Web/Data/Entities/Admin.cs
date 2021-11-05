namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Admin : IEntity
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        [Display (Name = "Imagen")]
        public string ImageUrl { get; set; }
        public User User { get; set; }
    }
}
