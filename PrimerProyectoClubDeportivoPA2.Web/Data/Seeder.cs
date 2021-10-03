using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;
using System;
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
                await CheckWeekday("Domingo");
            }

            if (!this.dataContext.Sports.Any())
            {
                await CheckSport("Fútbol");
                await CheckSport("Basketball");
                await CheckSport("Natación");
                await CheckSport("Clavados");
                await CheckSport("Zumba");
                await CheckSport("Baseball");
                await CheckSport("Golf");
                await CheckSport("Karate");
                await CheckSport("Ping Pong");
                await CheckSport("Tennis");
                await CheckSport("Box");
                await CheckSport("Atletismo");
            }

            if (!this.dataContext.Facilities.Any())
            {
                await CheckFacility("Alberca olímpica", "Cuenta con 8 carriles, tiene una profundidad de 2.7m y calefacción", "AO001");
                await CheckFacility("Alberca de clavados", "Cuenta con plataformas de clavados olímpicos tiene una profundidad de 5.4m, calefacción y jacuzzi", "AC002");
                await CheckFacility("Cancha de Tenis (Arcilla)", "Recientemente inagurada cuenta con gradas alrededor y videoarbitraje", "CT001");
                await CheckFacility("Cancha de Tenis (Pasto)", "Cuenta con gradas alrededor y videoarbitraje", "CT002");
                await CheckFacility("Campo de Golf", "Cuenta con 18 hoyos, fosa de arena y carritos de golf", "CG003");
                await CheckFacility("Campo de Baseball", "Cuenta con gradas para 200 personas, bancas de local y visitante y marcador digital", "CB004");
                await CheckFacility("Campo de Fútbol", "Cuenta con gradas para 300 personas, vestidores, regaderas y sauna", "CF005");
                await CheckFacility("Cancha de Basketball", "Cuenta con vestidores, tableros de acrílico y duela de madera", "CB006");
                await CheckFacility("Explanada", "Cuenta con techo retraíble y sonido envolvente", "EX001");
                await CheckFacility("Explanada-2", "Igualmente cuenta con techo retraíble y con tatami al centro", "EX002");
                await CheckFacility("Gimnasio", "Contamos con +50 equipos para ejercitarse, zona de cardio, zona de pesas y ring de boxeo", "GM001");
                await CheckFacility("Campo multiusos", "Cuenta con pista de atletismo de tartán con 6 carriles", "CM007");
            }

            if (!this.dataContext.MembershipTypes.Any())
            {
                await CheckMembershipType("Plata", "Te permite el acceso a los deportes: Fútbol, Basketball y Zumba", "$1500");
                await CheckMembershipType("Oro", "Incluye todos los deportes de la membresía Plata además de Karate, Ping Pong y Atletismo", "$2500");
                await CheckMembershipType("Platino", "Incluye todos los deportes de la membresía Oro además de Box, Natación, Clavados, Tennis y Golf", "$3500");
            }
        }
        private async Task CheckWeekday(string name)
        {
            this.dataContext.WeekDays.Add(new WeekDay { Name = name });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckSport(string name)
        {
            this.dataContext.Sports.Add(new Sport { Name = name });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckFacility(string name, string description, string code)
        {
            this.dataContext.Facilities.Add(new Facility
            {
                Name = name,
                Description = description,
                Code = code
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckMembershipType(string name, string description, string cost)
        {
            this.dataContext.MembershipTypes.Add(new MembershipType
            {
                Name = name,
                Description = description,
                Cost = cost
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckPermit(string name, Sport sport, MembershipType membershipType)
        {
            this.dataContext.Permits.Add(new Permit
            {
                Name = name,
                Sport = sport,
                MembershipType = membershipType
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckSchedule(DateTime startingHour, DateTime finishingHour, WeekDay weekDay, Facility facility)
        {
            this.dataContext.Schedules.Add(new Schedule
            {
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                WeekDay = weekDay,
                Facility = facility
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckTrainingSession(string name, Coach coach, Sport sport, Schedule schedule, int capacity)
        {
            this.dataContext.TrainingSessions.Add(new TrainingSession
            {
                Name = name,
                Coach = coach,
                Sport = sport,
                Schedule = schedule,
                Capacity = capacity
            });
            await this.dataContext.SaveChangesAsync();
        }
        private async Task CheckAgenda(Member member, TrainingSession trainingSession)
        {
            this.dataContext.Agendas.Add(new Agenda
            {
                Member = member,
                TrainingSession = trainingSession
            });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
