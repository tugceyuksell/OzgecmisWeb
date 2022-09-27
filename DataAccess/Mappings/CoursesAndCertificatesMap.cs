namespace DataAccess.Mappings
{
    public class CoursesAndCertificatesMap : IEntityTypeConfiguration<CoursesAndCertificates>
    {
        public void Configure(EntityTypeBuilder<CoursesAndCertificates> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Date).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasOne(x => x.PersonalInformation).WithMany(x => x.CoursesAndCertificates).HasForeignKey(x => x.PersonalInformationUID); //hata olabilir.
            builder.ToTable("CoursesAndCertificates");
        }
    }
}
