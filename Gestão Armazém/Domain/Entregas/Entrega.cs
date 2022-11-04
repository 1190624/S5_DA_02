using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Entregas {
    public class Entrega : Entity<Identificador>, IAggregateRoot {
        private DataEntrega dataEntrega;

        private Massa massa;

        private TempoColocação tempoColocação;

        private TempoRetirada tempoRetirada;


        public Entrega() {}

        public Entrega(Identificador identificador, DataEntrega dataEntrega, Massa massa, TempoColocação tempoColocação, TempoRetirada tempoRetirada) {
            this.dataEntrega = dataEntrega;
            this.massa = massa;
            this.tempoColocação = tempoColocação;
            this.tempoRetirada = tempoRetirada;
        }

        public DataEntrega dataEntrega => dataEntrega;

        public Massa massa => massa;

        public TempoColocação tempoColocação => tempoColocação;

        public TempoRetirada tempoRetirada => tempoRetirada;

    }
}