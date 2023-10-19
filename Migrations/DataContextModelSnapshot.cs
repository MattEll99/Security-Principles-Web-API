﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Security_Principles_Web_API.Data;

#nullable disable

namespace Security_Principles_Web_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Security_Principles_Web_API.Models.GroupMember", b =>
                {
                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<int>("securityPrincipleId")
                        .HasColumnType("int");

                    b.HasKey("groupId", "securityPrincipleId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("Security_Principles_Web_API.Models.SecurityPrinciple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("applicationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("displayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("principleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("displayName")
                        .IsUnique();

                    b.ToTable("SecurityPrinciples");
                });

            modelBuilder.Entity("Security_Principles_Web_API.Models.vGroupMembers", b =>
                {
                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<int>("memberId")
                        .HasColumnType("int");

                    b.Property<string>("groupDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memberDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memberPrincipleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId", "memberId");

                    b.ToTable((string)null);

                    b.ToView("vGroupMembers", (string)null);
                });

            modelBuilder.Entity("Security_Principles_Web_API.Models.GroupMember", b =>
                {
                    b.HasOne("Security_Principles_Web_API.Models.SecurityPrinciple", "Securityprinciple")
                        .WithMany("GroupMembers")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Securityprinciple");
                });

            modelBuilder.Entity("Security_Principles_Web_API.Models.SecurityPrinciple", b =>
                {
                    b.Navigation("GroupMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
