namespace DataAccess.Mappings
{
    public class ProjectsMap : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x=>x.Name).HasMaxLength(250);
            builder.Property(x => x.Image).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasOne(x => x.CategoriesProject).WithMany(x => x.Projects).HasForeignKey(x => x.CategoriesProjectUID);
            builder.HasOne(x => x.PersonalInformation).WithMany(x => x.Projects).HasForeignKey(x => x.PersonalInformationUID);
            builder.ToTable("Projects");
        }
    }
}
