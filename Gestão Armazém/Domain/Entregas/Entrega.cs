using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Entregas {
    public class Entrega : Entity<Identificador>, IAggregateRoot {

        private Identificador identificador;

        private DataEntrega dataEntrega;

        private Massa massa;

        private TempoColocação tempoColocação;

        private TempoRetirada tempoRetirada;


        public Entrega() {}

        public Entrega(Identificador identificador, DataEntrega dataEntrega, Massa massa, TempoColocação tempoColocação, TempoRetirada tempoRetirada) {
            this.identificador = identificador;
            this.dataEntrega = dataEntrega;
            this.massa = massa;
            this.tempoColocação = tempoColocação;
            this.tempoRetirada = tempoRetirada;
        }

        public Identificador Identificador => identificador;
        public DataEntrega DataEntrega => dataEntrega;

        public Massa Massa => massa;

        public TempoColocação TempoColocação => tempoColocação;

        public TempoRetirada TempoRetirada => tempoRetirada;

    }
}