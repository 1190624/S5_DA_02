using System;
using DDDSample1.Domain.Entregas.Factory;

namespace DDDSample1.Domain.Entregas.DTO {
    public class EntregasMapper {
        public static EntregasDTO toDTO(Entrega entrega){
            return new EntregasDTO(entrega.Identificador.GetValue,
            entrega.dataEntrega.GetDia,
            entrega.dataEntrega.GetMes,
            entrega.dataEntrega.GetAno,
            entrega.massa.massa,
            entrega.tempoColocação.GetTempoColocação,
            entrega.tempoRetirada.tempoRetirada);
        }

        public static Entrega toEntrega(EntregasDTO entregasDTO){
            return new EntregasFactory().CriarEntrega(entregasDTO.GetIdentificador,
            entregasDTO.GetDia,
            entregasDTO.GetMes,
            entregasDTO.GetAno,
            entregasDTO.GetMassa,
            entregasDTO.GetTempoColocação,
            entregasDTO.GetTempoRetirada);
        }
        
    }
}