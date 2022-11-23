using System;
using System.Text.RegularExpressions;
using DDDSample1.Domain.Shared;


namespace DDDSample1.Domain.Entregas.Validator {
    public class EntregasValidator : IValidator {

        private const String ID_REGEX = "^[0-9]{6}$";

        private const String ID_ARMAZEM = "^([A-Z]|[0-9]){3}$";

        private const String DIA_REGEX = "^([1-9]|[12][0-9]|3[01])$";

        private const String MES_REGEX = "^([1-9]|1[0-2])$";

        private const String ANO_REGEX = "^(20[0-9]{2})$";

        private const Double MASSA_MIN = 0;

        private const Double TEMPO_COLOCAÇÃO_MIN = 0;

        private const Double TEMPO_RETIRADA_MIN = 0;


        public bool IsValid(params Object[] listParameter){
            
           if(!Regex.IsMatch((String)listParameter[0], ID_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;");
            
            if(!Regex.IsMatch((String)listParameter[1],ID_ARMAZEM))
                throw new BusinessRuleValidationException("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;");

            if(!Regex.IsMatch((String)listParameter[2],DIA_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Dia da Entrega;\nO Identificador do dia da Entrega deve ser composto por um valor valido;");

            if(!Regex.IsMatch((String)listParameter[3],MES_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Mes da Entrega;\nO Identificador do mes da Entrega deve ser composto por um valor valido;");

            if(!Regex.IsMatch((String)listParameter[4],ANO_REGEX))
                throw new BusinessRuleValidationException("Formato inválido do Ano da Entrega;\nO Identificador do Ano da Entrega deve ser composto por um valor valido;");
            
            if (((Double) listParameter[5]) <= MASSA_MIN)
                throw new BusinessRuleValidationException("Formato inválido do valor da Massa;\nO Valor da Massa deve ser acima de 0;");
            
            if (((Double) listParameter[6]) <= TEMPO_COLOCAÇÃO_MIN)
                throw new BusinessRuleValidationException("Formato inválido do tempo de colocação;\nO Valor do tempo de colocação deve ser acima de 0;");
            
            if (((Double) listParameter[7]) <= TEMPO_RETIRADA_MIN)
                throw new BusinessRuleValidationException("Formato inválido do tempo de retirada;\nO Valor do tempo de retirada deve ser acima de 0;");

            return true;
        }


    } 
}