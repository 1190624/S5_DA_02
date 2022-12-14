// <auto-generated />
using DDDSample1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDDNetCore.Migrations
{
    [DbContext(typeof(DDDSample1DbContext))]
    [Migration("20221123191441_AddBaseDeDadosArmazens")]
    partial class AddBaseDeDadosArmazens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DDDSample1.Domain.Armazéns.Armazém", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("armazéns");
                });

            modelBuilder.Entity("DDDSample1.Domain.Categories.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DDDSample1.Domain.Entregas.Entrega", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ArmazémId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ArmazémId");

                    b.ToTable("entrega");
                });

            modelBuilder.Entity("DDDSample1.Domain.Families.Family", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("DDDSample1.Domain.Products.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DDDSample1.Domain.Armazéns.Armazém", b =>
                {
                    b.OwnsOne("DDDSample1.Domain.Armazéns.Coordenadas", "Coordenadas", b1 =>
                        {
                            b1.Property<string>("ArmazémId")
                                .HasColumnType("varchar(255)");

                            b1.Property<double>("latitude")
                                .HasColumnType("double");

                            b1.Property<double>("longitude")
                                .HasColumnType("double");

                            b1.HasKey("ArmazémId");

                            b1.ToTable("armazéns");

                            b1.WithOwner()
                                .HasForeignKey("ArmazémId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Armazéns.Designação", "Designação", b1 =>
                        {
                            b1.Property<string>("ArmazémId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("texto")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ArmazémId");

                            b1.ToTable("armazéns");

                            b1.WithOwner()
                                .HasForeignKey("ArmazémId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Armazéns.Endereço", "Endereço", b1 =>
                        {
                            b1.Property<string>("ArmazémId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("códigoPostal")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("localidade")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("nomeRua")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<short>("númeroPorta")
                                .HasColumnType("smallint");

                            b1.Property<string>("país")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ArmazémId");

                            b1.ToTable("armazéns");

                            b1.WithOwner()
                                .HasForeignKey("ArmazémId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Armazéns.Munícipio", "Munícipio", b1 =>
                        {
                            b1.Property<string>("ArmazémId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("nome")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ArmazémId");

                            b1.ToTable("armazéns");

                            b1.WithOwner()
                                .HasForeignKey("ArmazémId");
                        });

                    b.Navigation("Coordenadas");

                    b.Navigation("Designação");

                    b.Navigation("Endereço");

                    b.Navigation("Munícipio");
                });

            modelBuilder.Entity("DDDSample1.Domain.Entregas.Entrega", b =>
                {
                    b.HasOne("DDDSample1.Domain.Armazéns.Armazém", "armazem")
                        .WithMany("entregas")
                        .HasForeignKey("ArmazémId");

                    b.OwnsOne("DDDSample1.Domain.Entregas.DataEntrega", "DataEntrega", b1 =>
                        {
                            b1.Property<string>("EntregaId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ano")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("dia")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("mes")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("EntregaId");

                            b1.ToTable("entrega");

                            b1.WithOwner()
                                .HasForeignKey("EntregaId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Entregas.Massa", "Massa", b1 =>
                        {
                            b1.Property<string>("EntregaId")
                                .HasColumnType("varchar(255)");

                            b1.Property<double>("massa")
                                .HasColumnType("double");

                            b1.HasKey("EntregaId");

                            b1.ToTable("entrega");

                            b1.WithOwner()
                                .HasForeignKey("EntregaId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Entregas.TempoColocação", "TempoColocação", b1 =>
                        {
                            b1.Property<string>("EntregaId")
                                .HasColumnType("varchar(255)");

                            b1.Property<double>("tempoColocação")
                                .HasColumnType("double");

                            b1.HasKey("EntregaId");

                            b1.ToTable("entrega");

                            b1.WithOwner()
                                .HasForeignKey("EntregaId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Entregas.TempoRetirada", "TempoRetirada", b1 =>
                        {
                            b1.Property<string>("EntregaId")
                                .HasColumnType("varchar(255)");

                            b1.Property<double>("tempoRetirada")
                                .HasColumnType("double");

                            b1.HasKey("EntregaId");

                            b1.ToTable("entrega");

                            b1.WithOwner()
                                .HasForeignKey("EntregaId");
                        });

                    b.Navigation("DataEntrega");

                    b.Navigation("Massa");

                    b.Navigation("TempoColocação");

                    b.Navigation("TempoRetirada");

                    b.Navigation("armazem");
                });

            modelBuilder.Entity("DDDSample1.Domain.Armazéns.Armazém", b =>
                {
                    b.Navigation("entregas");
                });
#pragma warning restore 612, 618
        }
    }
}
