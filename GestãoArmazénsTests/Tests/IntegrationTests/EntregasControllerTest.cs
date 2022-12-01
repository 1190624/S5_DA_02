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
    public class EntregasControllerTest 
    {
        [Fact]
        public async Task Create_Sucess(){
            /*

            Entrega entrega1 = new EntregasFactory().CriarEntrega("123456","T16","20","10", "2020", 10, 10, 10);
            EntregasDTO entregasDTO = EntregasMapper.toDTO(entrega1);
            
         
            var mockEntregasRepository = new Mock<IEntregasRepository>();
            mockEntregasRepository.Setup(repository => repository.AddAsync(It.IsAny<Entrega>())).Returns(Task.FromResult(entrega1));

            var mockArmazemRepository = new Mock<IArmazémRepository>();

            var mockUnit = new Mock<IUnitOfWork>();

            EntregaService entregaService = new EntregaService(mockUnit.Object, mockEntregasRepository.Object, mockArmazemRepository.Object);
            EntregaController controller = new EntregaController(entregaService);

            var result = await controller.Create(entregasDTO);

            mockEntregasRepository.Verify(repository => repository.AddAsync(It.IsAny<Entrega>()), Times.AtLeastOnce());
            mockUnit.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<EntregasDTO>>(result);
            */
            }
    }
}