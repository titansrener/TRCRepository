﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRC.Data;

namespace TRC.Data.Migrations
{
    [DbContext(typeof(TrcContext))]
    [Migration("20191024024916_BABA")]
    partial class BABA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TRC.Core.Modelo.Estado", b =>
                {
                    b.Property<int>("Id_Estado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id_Estado");

                    b.ToTable("Estados");
                });
#pragma warning restore 612, 618
        }
    }
}
