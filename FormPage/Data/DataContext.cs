using FormPage.Entity;
using Microsoft.EntityFrameworkCore; 



namespace FormPage.Data
{
        public class Datacontext : DbContext
        {
           

            public DbSet<PersonInfo> PersonInfo { get; set; }
            public DbSet<Experience> Experience { get; set; }
            public DbSet<Courses> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-95J14PT;Database=Form;Integrated Security=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
                .HasOne(e => e.PersonInfo)
                .WithMany(p => p.Experience)
                .HasForeignKey(e => e.PersonInfoId);

            modelBuilder.Entity<Courses>()
                .HasOne(c => c.PersonInfo)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.PersonInfoId);
        }




    }
}