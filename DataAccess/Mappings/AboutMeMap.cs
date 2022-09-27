namespace DataAccess.Mappings
{
    public class AboutMeMap : IEntityTypeConfiguration<AboutMe>
    {
        public void Configure(EntityTypeBuilder<AboutMe> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.CoverLetter).IsRequired(false).HasMaxLength(300);
            builder.Property(x => x.ProfilImage).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.BoardImage).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");

            builder.HasOne(x => x.PersonalInformation).WithMany(x=>x.AboutMe).HasForeignKey(x => x.PersonalInformationUID); //hata olabilir.
            builder.ToTable("AboutMe");
        }
    }
}
