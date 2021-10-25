namespace PrimerProyectoClubDeportivoPA2.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboMembershipTypes();
    }
}
