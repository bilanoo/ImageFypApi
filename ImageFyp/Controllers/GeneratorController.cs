using ImageFyp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;

namespace ImageFyp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : Controller
    {
        // GET: Generator
        [HttpGet("{id}/{userText}")]
        public ActionResult GetGenerator(int id, string userText)
        {


            var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(id);
            var imageUrl = selectedBackgroundImage.Url;

            PointF firstLocation = new PointF(10f, 10f);

            Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 100))
                {
                    graphics.DrawString(userText, arialFont, Brushes.Blue, firstLocation);
                }

            }

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return File(stream.ToArray(), "image/jpeg");
            }

            

        }

        
        //[HttpGet("{id}/{userText}")]
        //public ActionResult GetGenerator(int id, string userText)
        //{


        //    var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(id);
        //    var imageUrl = selectedBackgroundImage.Url;
        //    var imageName = selectedBackgroundImage.Name;
        //    byte[] b = System.IO.File.ReadAllBytes(imageUrl);
        //    return File(b, imageName + "/jpeg");
        //}

        // POST api/Generator
        [HttpPost]
        public ActionResult Post([FromBody] GeneratorInstructions instructions)
        {


            var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(instructions.Id);
            var imageUrl = selectedBackgroundImage.Url;
            var imageName = selectedBackgroundImage.Name;
            byte[] b = System.IO.File.ReadAllBytes(imageUrl);
            return File(b, "image/jpeg");
        }


        
    }
}
