namespace DataAccess.Mappings
{
    public class CategoriesProjectMap : IEntityTypeConfiguration<CategoriesProject>
    {
        public void Configure(EntityTypeBuilder<CategoriesProject> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("datetime");
            builder.HasMany(x=>x.Projects).WithOne(x=>x.CategoriesProject).HasForeignKey(x=>x.CategoriesProjectUID).OnDelete(DeleteBehavior.Cascade);//Proje kategorileri silinince o proje kategorisine ait projelerde silinecek
            builder.ToTable("CategoriesProject");
        }
    }
}
