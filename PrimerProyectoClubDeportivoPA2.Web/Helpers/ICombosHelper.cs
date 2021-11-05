namespace PrimerProyectoClubDeportivoPA2.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboMembershipTypes();
        public IEnumerable<SelectListItem> GetComboWeekdays();
        public IEnumerable<SelectListItem> GetComboFacilities();

    }
}
