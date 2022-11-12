using DDDSample1.Domain.Armazéns;
using DDDSample1.Controllers;
using DDDSample1.Domain.Armazéns.Factory;
using DDDSample1.Domain.Armazéns.DTO;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Moq;

namespace Tests.TestesUnitarios.User
{
    public class ArmazemControllerTest 
    {
        [Fact]
        public async Task Create_Sucess(){
            Armazém armazém1 = new ArmazémFactory().CriarArmazém("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21);
            ArmazémDTO armazémDTO = ArmazémMapper.toDTO(armazém1);
            JObject armazemJSon = JObject.FromObject(armazémDTO);
         
            var mockRepository = new Mock<IArmazémRepository>();
            mockRepository.Setup(repository => repository.AddAsync(It.IsAny<Armazém>())).Returns(Task.FromResult(armazém1));

            var mockUnit = new Mock<IUnitOfWork>();

            RegistarArmazémService registarArmazémService = new RegistarArmazémService(mockRepository.Object, mockUnit.Object);
            RegistarArmazémController controller = new RegistarArmazémController(registarArmazémService);

            var result = await controller.Create(armazemJSon);

            mockRepository.Verify(repository => repository.AddAsync(It.IsAny<Armazém>()), Times.AtLeastOnce());
            mockUnit.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<ArmazémDTO>>(result);
        }

        [Fact]
        public async Task GetAll_Sucess(){ 
            var mockRepository = new Mock<IArmazémRepository>();
            mockRepository.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(new List<Armazém>()));

            var mockUnit = new Mock<IUnitOfWork>();

            ListarArmazénsService listarArmazénsService = new ListarArmazénsService(mockUnit.Object,mockRepository.Object);
            ListarArmazénsController listarArmazénsController = new ListarArmazénsController(listarArmazénsService);

            var result = await listarArmazénsController.GetAll();

            mockRepository.Verify(repository => repository.GetAllAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<IEnumerable<JObject>>>(result);
        }

        [Fact]
        public async Task GetById_Sucess(){
            Identificador id = new Identificador("exemplo");

            var mockRepository = new Mock<IArmazémRepository>();
            mockRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Identificador>()));

            var mockUnit = new Mock<IUnitOfWork>();

            RegistarArmazémService registarArmazémService = new RegistarArmazémService(mockRepository.Object, mockUnit.Object);
            RegistarArmazémController registarArmazémController = new RegistarArmazémController(registarArmazémService);

            var result = await registarArmazémController.GetById(id.ToString());

            mockRepository.Verify(repository => repository.GetByIdAsync(It.IsAny<Identificador>()), Times.AtLeastOnce());
            Assert.IsType<ActionResult<ArmazémDTO>>(result);
        }
    }
}