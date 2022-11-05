using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns;
using System;

namespace DDDSample1.Domain.Entregas {
    public class Entrega : Entity<Identificador>, IAggregateRoot {

        private string armazém;
        private DataEntrega dataEntrega;

        private Massa massa;

        private TempoColocação tempoColocação;

        private TempoRetirada tempoRetirada;


        public Entrega() {}

        public Entrega(Identificador identificador,string armazém, DataEntrega dataEntrega, Massa massa, TempoColocação tempoColocação, TempoRetirada tempoRetirada) {

            if(armazém == null){
                throw new BusinessRuleValidationException("Armazém não pode ter um valor nulo");
            }
            this.Id = identificador;
            this.armazém = armazém;
            this.dataEntrega = dataEntrega;
            this.massa = massa;
            this.tempoColocação = tempoColocação;
            this.tempoRetirada = tempoRetirada;
        }

        public string Armazém => armazém;
        public DataEntrega DataEntrega => dataEntrega;

        public Massa Massa => massa;

        public TempoColocação TempoColocação => tempoColocação;

        public TempoRetirada TempoRetirada => tempoRetirada;
        


        public void changeArmazém (String armazém){
            this.armazém = armazém;
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