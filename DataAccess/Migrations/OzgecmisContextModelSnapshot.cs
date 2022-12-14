// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(OzgecmisContext))]
    partial class OzgecmisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Abilities", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PersonalInformationUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.HasIndex("PersonalInformationUID");

                    b.ToTable("Abilities", (string)null);
                });

            modelBuilder.Entity("Entities.AboutMe", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoardImage")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CoverLetter")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("PersonalInformationUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfilImage")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.HasIndex("PersonalInformationUID");

                    b.ToTable("AboutMe", (string)null);
                });

            modelBuilder.Entity("Entities.CategoriesProject", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.ToTable("CategoriesProject", (string)null);
                });

            modelBuilder.Entity("Entities.CoursesAndCertificates", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PersonalInformationUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.HasIndex("PersonalInformationUID");

                    b.ToTable("CoursesAndCertificates", (string)null);
                });

            modelBuilder.Entity("Entities.Experience", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PersonalInformationUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.HasIndex("PersonalInformationUID");

                    b.ToTable("Experience", (string)null);
                });

            modelBuilder.Entity("Entities.Members", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("UID");

                    b.ToTable("Members", (string)null);
                });

            modelBuilder.Entity("Entities.PersonalInformation", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("DrivingLicense")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GitHub")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Licence")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Medium")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.ToTable("PersonalInformation", (string)null);
                });

            modelBuilder.Entity("Entities.Projects", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoriesProjectUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("PersonalInformationUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("UID");

                    b.HasIndex("CategoriesProjectUID");

                    b.HasIndex("PersonalInformationUID");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("Entities.Abilities", b =>
                {
                    b.HasOne("Entities.PersonalInformation", "PersonalInformation")
                        .WithMany("Abilities")
                        .HasForeignKey("PersonalInformationUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Entities.AboutMe", b =>
                {
                    b.HasOne("Entities.PersonalInformation", "PersonalInformation")
                        .WithMany("AboutMe")
                        .HasForeignKey("PersonalInformationUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Entities.CoursesAndCertificates", b =>
                {
                    b.HasOne("Entities.PersonalInformation", "PersonalInformation")
                        .WithMany("CoursesAndCertificates")
                        .HasForeignKey("PersonalInformationUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Entities.Experience", b =>
                {
                    b.HasOne("Entities.PersonalInformation", "PersonalInformation")
                        .WithMany("Experience")
                        .HasForeignKey("PersonalInformationUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Entities.Projects", b =>
                {
                    b.HasOne("Entities.CategoriesProject", "CategoriesProject")
                        .WithMany("Projects")
                        .HasForeignKey("CategoriesProjectUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.PersonalInformation", "PersonalInformation")
                        .WithMany("Projects")
                        .HasForeignKey("PersonalInformationUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriesProject");

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Entities.CategoriesProject", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Entities.PersonalInformation", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("AboutMe");

                    b.Navigation("CoursesAndCertificates");

                    b.Navigation("Experience");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
