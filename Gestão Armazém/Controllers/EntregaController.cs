using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Entregas.DTO;
using DDDSample1.Domain.Shared;
using System;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly EntregaService _service;

        public EntregaController(EntregaService service)
        {
            _service = service;
        }

        // PUT: api/EditarEntrega/id
       [HttpPut("{Id}")]
        public async Task<ActionResult<JObject>> EditarEntrega(String Id, JObject novaEntregaJSON)
        {
            
            if (Id.ToString() != novaEntregaJSON.ToObject<EntregasDTO>().GetIdentificador)
            {
                return BadRequest();
            }

            try
            {
                var entregaDTO = await _service.editarEntregaAsync(novaEntregaJSON.ToObject<EntregasDTO>());
                var response = JObject.FromObject(entregaDTO);
                
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

        [HttpGet("{ID}")]
        public async Task<ActionResult<EntregasDTO>> GetById(String Id) {
            var response = await _service.GetByIdAsync(Id);

            if (response == null)
                return NotFound();
            
            return response;
        }
        /*

        [HttpPost]
        public async Task<ActionResult<EntregasDTO>> Create(JObject entregaJSON) {
            try {
                var response = await _service.RegistarEntrega(entregaJSON.ToObject<EntregasDTO>());

                return CreatedAtAction(nameof(GetById), new {Id = response.identificador}, response);
            } catch (BusinessRuleValidationException exception) {
                return BadRequest(new {exception.Message});
            }

        }

*/
        [HttpPost]
        public async Task<ActionResult<EntregasDTO>> Create(EntregasDTO dto)
        {
            var list = await _service.GetAllAsync();
            if (list != null)
            {
                foreach (var deliveryDto in list)
                {
                    if (deliveryDto.GetIdentificador.Equals(dto.GetIdentificador))
                    {
                        return BadRequest(new
                            { Message = "This Delivery identifier already exists try another one." });
                    }
                }
            }
            
            try
            {
                var delivery = await _service.RegistarEntrega(dto);

                return CreatedAtAction(nameof(GetById), new { id = delivery.identificador }, delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // GET: api/Entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JObject>>> GetAll()
        {
            var listaEntregasDTO = await _service.GetAllAsync();

            List<JObject> listaEntregaJSON = new List<JObject>();

            foreach(EntregasDTO entregasDTO in listaEntregasDTO)
                listaEntregaJSON.Add(JObject.FromObject(entregasDTO));
            return listaEntregaJSON;
        }

    }
    
}