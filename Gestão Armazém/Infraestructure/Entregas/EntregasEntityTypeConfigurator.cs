using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazéns;

namespace DDDSample1.Infrastructure.Entregas{

    public class EntregasEntityTypeConfigurator : IEntityTypeConfiguration<Entrega> {

        public void Configure(EntityTypeBuilder<Entrega> entityTypeBuilder){
            entityTypeBuilder.HasKey(entrega => entrega.Id);
            entityTypeBuilder.HasAlternateKey(entrega => entrega.ArmazémId);
            entityTypeBuilder.OwnsOne(entrega => entrega.DataEntrega, dataEntrega => {dataEntrega.Property("dia").IsRequired(true);
                dataEntrega.Property("mes").IsRequired(true);
                dataEntrega.Property("ano").IsRequired(true);
                });
            entityTypeBuilder.OwnsOne(entrega => entrega.Massa, massa => {massa.Property("massa").IsRequired(true);});
            entityTypeBuilder.OwnsOne(entrega => entrega.TempoColocação, tempoColocação => {tempoColocação.Property("tempoColocação").IsRequired(true);});
            entityTypeBuilder.OwnsOne(entrega => entrega.TempoRetirada, tempoRetirada => {tempoRetirada.Property("tempoRetirada").IsRequired(true);});
        }
    }
}