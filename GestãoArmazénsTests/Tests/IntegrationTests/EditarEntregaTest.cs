using DDDSample1.Domain.Entregas;
using DDDSample1.Controllers;
using DDDSample1.Domain.Entregas.Factory;
using DDDSample1.Domain.Entregas.DTO;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Moq;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Armazéns.Factory;
using DDDSample1.Domain.Armazéns.DTO;

namespace Tests.TestesUnitarios.User
{
    public class EditarEntregaTest
    {
        [Fact]
        public async Task Update_Sucess()
        {
            /*
            Entrega entrega1 = new EntregasFactory().CriarEntrega("123459", "T16", "20", "10", "2022", 10, 10, 10);
            EntregasDTO dto = EntregasMapper.toDTO(entrega1);
            JObject entregaJSon = JObject.FromObject(dto);

            var mockRepository = new Mock<IEntregasRepository>();

            mockRepository.Setup(repository => repository.AddAsync(It.IsAny<Entrega>())).Returns(Task.FromResult(entrega1));

            Armazém armazém1 = new ArmazémFactory().CriarArmazém("T16", "Armazém Matosinhos", "2311-412", 2311, "Rua de Matosinhos",
               "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21);
            ArmazémDTO armazémDTO = ArmazémMapper.toDTO(armazém1);
            JObject armazemJSon = JObject.FromObject(armazémDTO);
            var mockRepositoryA = new Mock<IArmazémRepository>();
            mockRepositoryA.Setup(repository => repository.AddAsync(It.IsAny<Armazém>())).Returns(Task.FromResult(armazém1));

            var mockUnit = new Mock<IUnitOfWork>();
            EntregaService service = new EntregaService(mockUnit.Object, mockRepository.Object, mockRepositoryA.Object);

            EntregaController controller = new EntregaController(service);

            var result = await controller.EditarEntrega("123459", entregaJSon);    //armazemJSon);

            mockRepository.Verify(repository => repository.AddAsync(It.IsAny<Entrega>()), Times.AtLeastOnce());
            mockUnit.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<EntregasDTO>>(result);
            */
        }

    }
}