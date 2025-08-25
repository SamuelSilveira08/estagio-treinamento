using Domain;
using Service;
using System;
using System.IO;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Controllers.Controllers
{
    [System.Web.Http.RoutePrefix("api/bestiario")]
    public class BestiarioController : ApiController
    {

        private static readonly BestiarioService _service = new BestiarioService();

        [HttpPost]
        public IHttpActionResult Create([FromBody] BestiarioRecord entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            entity = _service.Create(entity);
            return Created($"/api/bestiario/{entity.Id}", entity);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

    }
}
