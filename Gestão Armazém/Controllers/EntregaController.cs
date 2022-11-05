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
       [HttpPut]
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
    }
}