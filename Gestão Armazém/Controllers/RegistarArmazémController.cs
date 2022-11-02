using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Armazéns.DTO;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Families;

namespace DDDSample1.Controllers {
    [Route("/api/[controller]")]
    [ApiController]
    public class RegistarArmazémController : ControllerBase {
        private readonly RegistarArmazémService service;

        public RegistarArmazémController(RegistarArmazémService service, FamilyService _service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArmazémDTO>>> GetAll()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ArmazémDTO>> GetById(String Id) {
            var response = await service.GetByIdAsync(Id);

            if (response == null)
                return NotFound();
            
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ArmazémDTO>> Create(JObject armazémJSON) {
            try {
                var response = await service.RegistarArmazém(armazémJSON.ToObject<ArmazémDTO>());

                return CreatedAtAction(nameof(GetById), new {Id = response.identificador}, response);
            } catch (BusinessRuleValidationException exception) {
                return BadRequest(new {exception.Message});
            }
        }
    }
}