using System;
using System.Text.RegularExpressions;
using DDDSample1.Domain.Shared;


namespace DDDSample1.Domain.Entregas.Validator {
    public class EntregasValidator : IValidator {

        // TODO ID DIA MES ANO
        private const String ID_REGEX = "[0-9]{6}";

        private const String ID_ARMAZEM = "([A-Z]|[0-9]){3}";

        private const String DIA_REGEX = "";

        private const String MES_REGEX = "";

        private const String ANO_REGEX = "";

        private const Double MASSA_MIN = 0;

        private const Double TEMPO_COLOCAÇÃO_MIN = 0;

        private const Double TEMPO_RETIRADA_MIN = 0;


        public bool IsValid(params Object[] listParameter){
            return true;
        }


    } 
}