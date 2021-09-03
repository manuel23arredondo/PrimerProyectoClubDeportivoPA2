namespace PrimerProyectoClubDeportivoPA2.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }

    }


}
