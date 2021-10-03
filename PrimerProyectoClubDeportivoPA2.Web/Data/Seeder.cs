using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoClubDeportivoPA2.Web.Data
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        //private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            if (!this.dataContext.WeekDays.Any())
            {
                await CheckWeekday("Lunes");
                await CheckWeekday("Martes");
                await CheckWeekday("Miércoles");
                await CheckWeekday("Jueves");
                await CheckWeekday("Viernes");
                await CheckWeekday("Sábado");
            }
        }
        private async Task CheckWeekday(string name)
        {
            this.dataContext.WeekDays.Add(new WeekDay { Name = name });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
