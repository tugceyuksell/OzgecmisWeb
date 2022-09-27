namespace DataAccess.Mappings
{
    public class ExperienceMap : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.StartedDate).HasColumnType("datetime");
            builder.Property(x => x.EndDate).IsRequired(false).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasOne(x => x.PersonalInformation).WithMany(x => x.Experience).HasForeignKey(x => x.PersonalInformationUID); //hata olabilir.
            builder.ToTable("Experience");
        }
    }
}
