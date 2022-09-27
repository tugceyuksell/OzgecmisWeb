namespace DataAccess.Mappings
{
    public class MembersMap : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.HasKey(x => x.UID);
            builder.Property(x => x.NameSurname).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Password).HasMaxLength(20);
            builder.Property(x => x.Role).HasMaxLength(50);
            builder.ToTable("Members");
        }
    }
}
