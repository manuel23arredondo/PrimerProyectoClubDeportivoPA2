namespace PrimerProyectoClubDeportivoPA2.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sport> Sports { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
