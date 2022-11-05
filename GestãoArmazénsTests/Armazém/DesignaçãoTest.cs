using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazéns;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TestesUnitarios.User
{
    public class DesignaçãoTest
    {

        [Fact]
        public void CriarDesignaçãoNormal()
        {
            const string designação = "Teste Designação";
            var d = new Designação(designação);
            Assert.Equal(designação,d.GetTexto);
        }

        [Fact]
        public void FailCriarDesignaçãoNull()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Designação(null));
        }
    }
}