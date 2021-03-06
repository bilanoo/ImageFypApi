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
        //GET: Generator
       [HttpGet("{id}/{userText}")]
        public ActionResult GetEditLocalImages(int id, string userText)
        {


            var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(id);
            var imageUrl = selectedBackgroundImage.Url;

            PointF textLocation = new PointF(10f, 10f);

            Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 100))
                {
                    graphics.DrawString(userText, arialFont, Brushes.Blue, textLocation);
                }

            }

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return File(stream.ToArray(), "image/jpeg");
            }



        }

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

            // declared a brush and the colour value will be assigned via the property
            SolidBrush fontBrush = new SolidBrush(Color.FromName(instructions.FontColour));


            Bitmap bitmap = new Bitmap(responseStream);

            Bitmap bitmap2 = new Bitmap(bitmap);

            
            using (Graphics graphics = Graphics.FromImage(bitmap2))
            {
                using (Font fontType = new Font(instructions.FontName, instructions.FontSize))
                {
                    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    graphics.DrawString(instructions.UserText, fontType, fontBrush, rect, sf);

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
