using ImageFyp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageFyp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundImageController : ControllerBase
    {
        // GET: api/<BackgroundImageController>
        [HttpGet]
        public IEnumerable<BackgroundImage> Get()
        {
            yield return new BackgroundImage
            {
                Id = 1,
                Name = "yao.jpg"
            };
        }

        // GET api/<BackgroundImageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BackgroundImageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BackgroundImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BackgroundImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
