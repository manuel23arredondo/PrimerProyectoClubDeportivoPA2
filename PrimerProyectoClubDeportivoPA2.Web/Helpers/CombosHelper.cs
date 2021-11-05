namespace PrimerProyectoClubDeportivoPA2.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PrimerProyectoClubDeportivoPA2.Web.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboMembershipTypes()
        {
            var list = this.dataContext.MembershipTypes.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona un tipo de membresía",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboWeekdays()
        {
            var list = this.dataContext.WeekDays.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona un día",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboFacilities()
        {
            var list = this.dataContext.Facilities.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona una instalación",
                Value = "0"
            });
            return list;
        }
    }
}
