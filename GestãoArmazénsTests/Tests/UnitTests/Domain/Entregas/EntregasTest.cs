using System;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Entregas.Factory;
using DDDSample1.Domain.Shared;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TestesUnitarios.User
{
    public class EntregasTest
    {

        [Fact]
        public void CriarEntregaSucess()
        {
            Entrega entrega1 = new EntregasFactory().CriarEntrega("123456", "T16", "20","10","2020", 10, 10, 10);
            
            Identificador identificador = new Identificador("123456");
            DataEntrega dataEntrega = new DataEntrega("20","10","2020");
            Massa massa = new Massa(10);
            TempoColocação tempoColocação = new TempoColocação(10);
            TempoRetirada tempoRetirada = new TempoRetirada(10);

            Entrega entrega2 = new Entrega(identificador,"T16",dataEntrega, massa, tempoColocação, tempoRetirada);

            Assert.Equal(entrega1.Id, entrega2.Id);
        }

        [Fact]
        public void CriarEntregaComIDNull()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("1234567", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("A", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDInvalido3()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("AAAAAAAAAAAA", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDInvalido4()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123AAADADAD", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDInvalido5()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("1234ASD", "T16", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador da Entrega;\nO Identificador da Entrega deve ser composto por 6 caratéres numéricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDArmazemInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T161", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDArmazemInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16T", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDArmazemInvalido3()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDArmazemInvalido4()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "11", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComIDArmazemNull()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "", "20","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Identificador do Armazém;\nO Identificador do Armazém deve ser composto por 3 caratéres alfanuméricos;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComDiaInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "222","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Dia da Entrega;\nO Identificador do dia da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComDiaInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "55","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Dia da Entrega;\nO Identificador do dia da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComDiaInvalido3()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "0","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Dia da Entrega;\nO Identificador do dia da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComDiaNull()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "","10","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Dia da Entrega;\nO Identificador do dia da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMesInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "22","333","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Mes da Entrega;\nO Identificador do mes da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMesInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "5","33","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Mes da Entrega;\nO Identificador do mes da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMesInvalido3()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "5","0","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Mes da Entrega;\nO Identificador do mes da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMesNull()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","","2020", 10, 10, 10));
            Assert.Equal("Formato inválido do Mes da Entrega;\nO Identificador do mes da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComAnoInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","20200", 10, 10, 10));
            Assert.Equal("Formato inválido do Ano da Entrega;\nO Identificador do Ano da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComAnoInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","202", 10, 10, 10));
            Assert.Equal("Formato inválido do Ano da Entrega;\nO Identificador do Ano da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComAnoInvalido3()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","3000", 10, 10, 10));
            Assert.Equal("Formato inválido do Ano da Entrega;\nO Identificador do Ano da Entrega deve ser composto por um valor valido;", entrega.Message);
        }
        
        [Fact]
        public void CriarEntregaComAnoNull()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","", 10, 10, 10));
            Assert.Equal("Formato inválido do Ano da Entrega;\nO Identificador do Ano da Entrega deve ser composto por um valor valido;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMassaInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", 0, 10, 10));
            Assert.Equal("Formato inválido do valor da Massa;\nO Valor da Massa deve ser acima de 0;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComMassaInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", -1, 10, 10));
            Assert.Equal("Formato inválido do valor da Massa;\nO Valor da Massa deve ser acima de 0;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComTempoColocaçãoInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", 10, 0, 10));
            Assert.Equal("Formato inválido do tempo de colocação;\nO Valor do tempo de colocação deve ser acima de 0;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComTempoColocaçãoInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", 10, -1, 10));
            Assert.Equal("Formato inválido do tempo de colocação;\nO Valor do tempo de colocação deve ser acima de 0;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComTempoRetiradaInvalido()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", 10, 10, 0));
            Assert.Equal("Formato inválido do tempo de retirada;\nO Valor do tempo de retirada deve ser acima de 0;", entrega.Message);
        }

        [Fact]
        public void CriarEntregaComTempoRetiradaInvalido2()
        {
            var entrega = Assert.Throws<BusinessRuleValidationException>(() => new EntregasFactory().CriarEntrega("123456", "T16", "3","10","2020", 10, 10, -1));
            Assert.Equal("Formato inválido do tempo de retirada;\nO Valor do tempo de retirada deve ser acima de 0;", entrega.Message);
        }





        
    }
}