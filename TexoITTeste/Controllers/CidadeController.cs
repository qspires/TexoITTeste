using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TexoITTeste.Controllers
{
    [RoutePrefix("api/Cidade")]
    public class CidadeController : ApiController
    {

        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [Route("{id:int}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [AllowAnonymous]
        [Route("{id:int}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        [AllowAnonymous]
        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
