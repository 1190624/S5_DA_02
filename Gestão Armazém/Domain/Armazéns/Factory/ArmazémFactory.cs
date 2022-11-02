using System;
using DDDSample1.Domain.Armazéns.Validator;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazéns.Factory {
    public class ArmazémFactory : IArmazémFactory {
        public Armazém CriarArmazém(String identificador,
            String designação, 
            String códigoPostal, 
            Int16 númeroPorta, 
            String nomeRua, 
            String localidade,
            String país,
            String munícipio,
            Double latitude,
            Double longitude) {
                ArmazémValidator armazémValidator = new ArmazémValidator();

                if (armazémValidator.IsValid(identificador,
                    designação, 
                    códigoPostal, 
                    númeroPorta, 
                    nomeRua, 
                    localidade,
                    país, 
                    munícipio, 
                    latitude, 
                    longitude))
                    return new Armazém(new Identificador(identificador),
                        new Designação(designação),
                        new Endereço(códigoPostal, númeroPorta, nomeRua, localidade, país),
                        new Munícipio(munícipio),
                        new Coordenadas(latitude, longitude));

                return null;
            }
    }
}