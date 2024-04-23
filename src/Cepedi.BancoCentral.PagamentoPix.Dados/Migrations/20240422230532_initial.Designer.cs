﻿// <auto-generated />
using System;
using Cepedi.BancoCentral.PagamentoPix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240422230532_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.ContaEntity", b =>
                {
                    b.Property<int>("IdConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConta"));

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConta");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Contas", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdPessoa");

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", b =>
                {
                    b.Property<int>("IdPix")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPix"));

                    b.Property<string>("ChavePix")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPix")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPix");

                    b.HasIndex("IdConta");

                    b.ToTable("Pix", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.TransacaoPixEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChaveDeSeguranca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChavePix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPixDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdPixOrigem")
                        .HasColumnType("int");

                    b.Property<int?>("PixEntityIdPix")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPixDestino");

                    b.HasIndex("IdPixOrigem");

                    b.HasIndex("PixEntityIdPix");

                    b.ToTable("TransacaoPix", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("CelularValidado")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.ContaEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PessoaEntity", "Pessoa")
                        .WithMany("Contas")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.ContaEntity", "Conta")
                        .WithMany("Pixs")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.TransacaoPixEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", null)
                        .WithMany()
                        .HasForeignKey("IdPixDestino")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", null)
                        .WithMany()
                        .HasForeignKey("IdPixOrigem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", null)
                        .WithMany("TransacoesPixs")
                        .HasForeignKey("PixEntityIdPix");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.ContaEntity", b =>
                {
                    b.Navigation("Pixs");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity", b =>
                {
                    b.Navigation("TransacoesPixs");
                });
#pragma warning restore 612, 618
        }
    }
}