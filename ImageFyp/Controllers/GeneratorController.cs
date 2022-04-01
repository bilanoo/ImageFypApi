using ImageFyp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;
using System.Net;



namespace ImageFyp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : Controller
    {
       
        [HttpGet]
        public IActionResult GetImageFromExternalUrl(string externalUrl)
        {
            externalUrl = "https://i.stack.imgur.com/KOU3H.png";
            WebRequest request = WebRequest.Create(externalUrl);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            Bitmap bitmap2 = new Bitmap(responseStream);

            using (var stream = new MemoryStream())
            {
                bitmap2.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return File(stream.ToArray(), "image/jpeg");
            }
        }

        [HttpPost]
        public IActionResult AddTextToExternalImages([FromBody] GeneratorInstructions instructions)
        {

            WebRequest request = WebRequest.Create(instructions.ExternalImageUrl);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            

            Bitmap bitmap = new Bitmap(responseStream);

            PointF textLocation = new PointF(10f, 10f);

            Bitmap bitmap2 = new Bitmap(bitmap);

            using (Graphics graphics = Graphics.FromImage(bitmap2))
            {
                using (Font fontType = new Font(instructions.FontName, instructions.FontSize))
                {
                    
                    graphics.DrawString(instructions.UserText, fontType, Brushes.Blue, textLocation);
                }

            }

            using (var stream = new MemoryStream())
            {
                bitmap2.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return File(stream.ToArray(), "image/png");
            }
        }



    }
}
