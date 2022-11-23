using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns;
using System;

namespace DDDSample1.Domain.Entregas {
    public class Entrega : Entity<Identificador>, IAggregateRoot {

        private Identificador armazémId;
        private DataEntrega dataEntrega;
        private Massa massa;

        private TempoColocação tempoColocação;

        private TempoRetirada tempoRetirada;

         public Armazém armazem{get;set;}

        public Entrega() {}

        public Entrega(Identificador identificador, String armazémId, DataEntrega dataEntrega, Massa massa, TempoColocação tempoColocação, TempoRetirada tempoRetirada) {

            if(armazémId == null){
                throw new BusinessRuleValidationException("Armazém não pode ter um valor nulo");
            }
            this.Id = identificador;
           // this.armazém = armazém;
            this.armazémId = new Identificador(armazémId);
            this.dataEntrega = dataEntrega;
            this.massa = massa;
            this.tempoColocação = tempoColocação;
            this.tempoRetirada = tempoRetirada;
        }

        public Identificador ArmazémId => armazémId;
        public DataEntrega DataEntrega => dataEntrega;

        public Massa Massa => massa;

        public TempoColocação TempoColocação => tempoColocação;

        public TempoRetirada TempoRetirada => tempoRetirada;
        


        public void changeArmazém (String armazém){
            this.armazémId = new Identificador(armazém);
        }

        public void changeDataEntrega(String dia, String mês, String ano){
            this.dataEntrega = new DataEntrega(dia, mês, ano);
        }

        public void changeMassa(Double massa){
            this.massa = new Massa(massa);
        }

        public void changeTempoColocação(Double tempoColocação){
            this.tempoColocação = new TempoColocação(tempoColocação);
        }

        public void changeTempoRetirada(Double tempoRetirada){
            this.tempoRetirada = new TempoRetirada(tempoRetirada);
        }
    }
}