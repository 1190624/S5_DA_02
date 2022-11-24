using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Armazéns.DTO;
using DDDSample1.Domain.Shared;
using Microsoft.AspNetCore.Authorization;

namespace DDDSample1.Controllers {
    [Route("/api/armazem")]
    [ApiController]
    public class RegistarArmazémController : ControllerBase {
        private readonly RegistarArmazémService service;

        public RegistarArmazémController(RegistarArmazémService service) {
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

        [HttpDelete("{ID}")]
        //[Authorize]
        public async Task<ActionResult<JObject>> HardDelete(String Id)
        {
            try
            {
                var response = await service.DeleteAsync(Id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}