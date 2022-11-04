using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Armazéns;

namespace DDDSample1.Infrastructure.Armazéns {
    public class ArmazémEntityTypeConfiguration : IEntityTypeConfiguration<Armazém> {
        public void Configure(EntityTypeBuilder<Armazém> entityTypeBuilder) {
            entityTypeBuilder.HasKey(armazém => armazém.Id);
            entityTypeBuilder.OwnsOne(armazém => armazém.Designação,
                designação => {designação.Property("texto").IsRequired(true);});
            entityTypeBuilder.OwnsOne(armazém => armazém.Endereço, endereço => { 
                endereço.Property("códigoPostal").IsRequired(true);
                endereço.Property("númeroPorta").IsRequired(true);
                endereço.Property("nomeRua").IsRequired(true);
                endereço.Property("localidade").IsRequired(true);
                endereço.Property("país").IsRequired(true);
                });
            entityTypeBuilder.OwnsOne(armazém => armazém.Munícipio,
                munícipio => {munícipio.Property("nome").IsRequired(true);});
            entityTypeBuilder.OwnsOne(armazém => armazém.Coordenadas, coordenadas => {
                coordenadas.Property("latitude").IsRequired(true);
                coordenadas.Property("longitude").IsRequired(true);
            });
        }
    }
}