using System;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Armazéns.Factory;
using DDDSample1.Domain.Shared;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TestesUnitarios.User
{
    public class ArmazemTest
    {

        [Fact]
        public void CriarArmazémSucess()
        {
            Armazém armazém1 = new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21);

            Identificador identificador = new Identificador("T16");
            Designação designação = new Designação("Armazém Matosinhos");
            Endereço endereço = new Endereço("2311-412", 2311, "Rua de Matosinhos", "Senhora da Hora", "Portugal");
            Munícipio munícipio = new Munícipio("Matosinhos");
            Coordenadas coordenadas = new Coordenadas(23.21, 23.21);

            Armazém armazém2 = new Armazém(identificador,designação,endereço,munícipio,coordenadas);

            Assert.Equal(armazém1.Id, armazém2.Id);
        }

        [Fact]
        public void CriarArmazémComIDNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComIDInválido()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("ABC1","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComIDInválido2()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("123454","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComIDInválido3()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("TTT123","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComIDInválido4()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("abc","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComDesignacaoNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido da Designação do Armazém;\nA Designação do Armazém é um texto obrigatório com um máximo de 50 caratéres;", ex.Message);
        }
        
        [Fact]
        public void CriarArmazémComDesignacaoCom51Caracteres()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido da Designação do Armazém;\nA Designação do Armazém é um texto obrigatório com um máximo de 50 caratéres;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComCodigoPostalNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Código Postal do Armazém;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComCodigoPostalInvalido1()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","412-2311", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Código Postal do Armazém;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComCodigoPostalInvalido2()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","abcd-abc", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Código Postal do Armazém;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComNumeroPortaNegativo()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", -1, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Número da Porta do Armazém;\nO Número da Porta ultrapassa o limite máximo estabelecido (9999);", ex.Message);
        }

        [Fact]
        public void CriarArmazémComNumeroPortaAcimaLimite()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 10000, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Formato inválido do Número da Porta do Armazém;\nO Número da Porta ultrapassa o limite máximo estabelecido (9999);", ex.Message);
        }

        [Fact]
        public void CriarArmazémComNomeRuaNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Necessário estipular o Nome da Rua do Armazém;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComLocalidadeNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "", "Portugal", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Necessário estipular a Localidade do Armazém;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComPaisNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "", "Matosinhos", 23.21, 23.21));
            Assert.Equal("Necessário estipular o País do Armazém;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComMunicipioNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "", 23.21, 23.21));
            Assert.Equal("Necessário estipular o Munícipio do Armazém;", ex.Message);
        }

        [Fact]
        public void CriarArmazémComLatitudeMenorQue90()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", -91, 23.21));
            Assert.Equal("Formato inválido da Latitude do Armazém;\nO valor da Latitude deve ser entre \"-90\" e \"90\";", ex.Message);
        }

        [Fact]
        public void CriarArmazémComLatitudeMaiorQue90()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 91, 23.21));
            Assert.Equal("Formato inválido da Latitude do Armazém;\nO valor da Latitude deve ser entre \"-90\" e \"90\";", ex.Message);
        }

        [Fact]
        public void CriarArmazémComLongitudeMenorQue180()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, -181));
            Assert.Equal("Formato inválido da Longitude do Armazém;\nO valor da Longitude deve ser entre \"-180\" e \"180\";", ex.Message);
        }

        [Fact]
        public void CriarArmazémComLongitudeMaiorQue180()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 181));
            Assert.Equal("Formato inválido da Longitude do Armazém;\nO valor da Longitude deve ser entre \"-180\" e \"180\";", ex.Message);
        }
    }
}