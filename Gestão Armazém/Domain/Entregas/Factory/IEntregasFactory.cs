using System;

namespace DDDSample1.Domain.Entregas.Factory {
    public interface IEntregasFactory {
        public Entrega CriarEntrega(String identificador,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocação,
            Double tempoRetirada);
    }
}