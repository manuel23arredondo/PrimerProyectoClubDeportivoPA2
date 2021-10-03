using System;

namespace PrimerProyectoClubDeportivoPA2.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Member : IEntity
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        public User user;
        public MembershipType MembershipType;
    }
}
