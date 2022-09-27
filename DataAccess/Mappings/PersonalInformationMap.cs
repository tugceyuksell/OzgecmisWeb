namespace DataAccess.Mappings
{
    public class PersonalInformationMap : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.NameSurname).HasMaxLength(200);
            builder.Property(x => x.Licence).HasMaxLength(200);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Phone).HasMaxLength(200);
            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.LinkedIn).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.GitHub).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Medium).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Gender).HasMaxLength(50);
            builder.Property(x => x.DrivingLicense).IsRequired(false).HasMaxLength(5);
            builder.Property(x => x.DateOfBirth).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasMany(x => x.AboutMe).WithOne(x => x.PersonalInformation).HasForeignKey(x => x.PersonalInformationUID);
            builder.HasMany(x => x.Abilities).WithOne(x => x.PersonalInformation).HasForeignKey(x => x.PersonalInformationUID);
            builder.HasMany(x => x.Experience).WithOne(x => x.PersonalInformation).HasForeignKey(x => x.PersonalInformationUID);
            builder.HasMany(x => x.CoursesAndCertificates).WithOne(x => x.PersonalInformation).HasForeignKey(x => x.PersonalInformationUID);

            builder.ToTable("PersonalInformation");
        }
    }
}
