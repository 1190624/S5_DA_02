using System;
using DDDSample1.Domain.Entregas.Validator;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns;

namespace DDDSample1.Domain.Entregas.Factory {
    public class EntregasFactory : IEntregasFactory {
        public Entrega CriarEntrega(String identificador,
            String armazém,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocação,
            Double tempoRetirada
            ){
            EntregasValidator entregasValidator = new EntregasValidator();
        
            if(entregasValidator.IsValid(identificador,
                armazém,
                dia,
                mes,
                ano,
                massa,
                tempoColocação,
                tempoRetirada))
                return new Entrega(new Identificador(identificador), armazém, new DataEntrega(dia,mes,ano), new Massa(massa), new TempoColocação(tempoColocação), new TempoRetirada(tempoRetirada));

            return null;
        }
    }
}