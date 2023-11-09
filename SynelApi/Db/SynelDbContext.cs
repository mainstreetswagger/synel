using Microsoft.EntityFrameworkCore;
using SynelApi.Entities;

namespace SynelApi.Db
{
    public class SynelDbContext : DbContext
    {
        public DbSet<Employee> People { get; set; }
        public SynelDbContext(DbContextOptions<SynelDbContext> options)
            : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>()
        //        .HasData(new
        //        {
        //            PayrollNumber = "COOP08",
        //            Forename = "John",
        //            Surename = "William",
        //            DateOfBirth = DateTime.ParseExact("26/01/1955", "dd/MM/yyyy", null),
        //            Telephone = "12345678",
        //            Mobile = "987654231",
        //            Address = "12 Foreman road",
        //            Address2 = "London",
        //            Postcode = "GU12 6JW",
        //            EmailHome = "nomadic20@hotmail.co.uk",
        //            StartDate = DateTime.ParseExact("18/04/2013", "dd/MM/yyyy", null)
        //        },
        //        new
        //        {
        //            PayrollNumber = "JACK13",
        //            Forename = "Jerry",
        //            Surename = "Jackson",
        //            DateOfBirth = DateTime.ParseExact("11/05/1974", "dd/MM/yyyy", null),
        //            Telephone = "2050508",
        //            Mobile = "6987457",
        //            Address = "115 Spinney Road",
        //            Address2 = "Luton",
        //            Postcode = "LU33DF",
        //            EmailHome = "gerry.jackson@bt.com",
        //            StartDate = DateTime.ParseExact("18/04/2013", "dd/MM/yyyy", null)
        //        });
        //}
    }
}
