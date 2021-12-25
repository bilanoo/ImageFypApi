using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageFyp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : Controller
    {
        // GET: Generator

        [HttpGet("{id}")]
        public ActionResult GetGenerator(int id)
        {
            
            var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(id);
            var imageUrl = selectedBackgroundImage.Url;
            var imageName = selectedBackgroundImage.Name;
            byte[] b = System.IO.File.ReadAllBytes(imageUrl);
            return File(b, imageName + "/jpeg");
        }

        
    }
}
