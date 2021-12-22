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
        // GET: all backgrounds.
        [HttpGet]
        public IActionResult GetBackground()
        {
            return Ok(BackgroundData.GetBackgroundImages());
        }

        // Get individual ID, if invalid ID is prompt then, display not Found.
        [HttpGet("{id}")]
        public IActionResult GetBackgroundId(int id)
        {
            return Ok(BackgroundData.GetBackgroundImageById(id));
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
