using System;

namespace DDDSample1.Domain.Armazéns.Factory {
    public interface IArmazémFactory {
        public Armazém CriarArmazém(String identifier,
            String designação, 
            String códigoPostal, 
            Int16 númeroPorta, 
            String nomeRua, 
            String localidade,
            String país,
            String munícipio,
            Double latitude,
            Double longitude);
    }
}