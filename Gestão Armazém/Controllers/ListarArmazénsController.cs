using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Armazéns.DTO;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarArmazénsController : ControllerBase
    {
        private readonly ListarArmazénsService _service;

        public ListarArmazénsController(ListarArmazénsService service)
        {
            _service = service;
        }
        
        // GET: api/Armazéns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JObject>>> GetAll()
        {
            var listaArmazemDTO = await _service.GetAllAsync();

            List<JObject> listaArmazemJSON = new List<JObject>();

            foreach(ArmazémDTO armazémDTO in listaArmazemDTO)
                listaArmazemJSON.Add(JObject.FromObject(armazémDTO));
            return listaArmazemJSON;
        }
    }
}
