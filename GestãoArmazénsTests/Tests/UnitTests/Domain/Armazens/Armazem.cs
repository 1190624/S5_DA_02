using System;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TestesUnitarios.User
{
    public class DesignaçãoTest
    {

        [Fact]
        public void CriarArmazémNormal()
        {
            Identificador identificador = new Identificador("T16");
            Designação designação = new Designação("Armazém Matosinhos");
            Endereço endereço = new Endereço("2311-412", 2311, "Rua de Matosinhos", "Senhora da Hora", "Portugal");
            Munícipio munícipio = new Munícipio("Matosinhos");
            Coordenadas coordenadas = new Coordenadas(23.21, 23.21);

            Armazém armazém1 = new Armazém(identificador,designação,endereço,munícipio,coordenadas);

            Assert.Equal(armazém1.Id, identificador);
        }
    }
}