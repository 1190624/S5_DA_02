using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns.DTO;
using DDDSample1.Domain.Shared;
using System;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditarArmazémController : ControllerBase
    {
        private readonly EditarArmazémService _service;

        public EditarArmazémController(EditarArmazémService service)
        {
            _service = service;
        }

        // PUT: api/EditarArmazém/id
       [HttpPut("{Id}")]
        public async Task<ActionResult<JObject>> EditarArmazém(String Id, JObject novoArmazémJSON)
        {
            
            if (Id.ToString() != novoArmazémJSON.ToObject<ArmazémDTO>().GetIdentificador)
            {
                return BadRequest();
            }

            try
            {
                var armazémDTO = await _service.EditarArmazémAsync(novoArmazémJSON.ToObject<ArmazémDTO>());
                var response = JObject.FromObject(armazémDTO);
                
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