namespace DataAccess.Mappings
{
    public class AbilitiesMap : IEntityTypeConfiguration<Abilities>
    {
        public void Configure(EntityTypeBuilder<Abilities> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Rating).HasColumnType("tinyint");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasOne(x => x.PersonalInformation).WithMany(x => x.Abilities).HasForeignKey(x => x.PersonalInformationUID); //hata olabilir.
            builder.ToTable("Abilities");
        }
    }
}
