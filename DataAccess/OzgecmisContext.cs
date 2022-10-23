using DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OzgecmisContext : DbContext
    {
        public DbSet<CategoriesProject> CategoriesProjects { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Abilities> Abilities { get; set; }
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<CoursesAndCertificates> CoursesAndCertificates { get; set; }
        public DbSet<Members> Members { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LT20;Database=OzgecmisWeb;Trusted_Connection=True;");
        }
        // Veritabanında işlem yapılacağı zaman Mapping Olayını Gerçekleştiren Metot.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesProjectMap());
            modelBuilder.ApplyConfiguration(new ProjectsMap());
            modelBuilder.ApplyConfiguration(new AbilitiesMap());
            modelBuilder.ApplyConfiguration(new AboutMeMap());
            modelBuilder.ApplyConfiguration(new ExperienceMap());
            modelBuilder.ApplyConfiguration(new PersonalInformationMap());
            modelBuilder.ApplyConfiguration(new CoursesAndCertificatesMap());
            modelBuilder.ApplyConfiguration(new MembersMap());
        }
    }
}
