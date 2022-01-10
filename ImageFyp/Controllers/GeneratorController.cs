using ImageFyp.Models;
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

        //[HttpPost]
        //public IActionResult ExternalImageFromUrl([FromBody] GeneratorInstructions instruction)
        //{
        //    var externalImageUrl = instruction.ExternalImageUrl;

        //    using (WebClient client = new WebClient())
        //    {
        //        byte[] dataArr = client.DownloadData(externalImageUrl);

        //        File.WriteAllBytes(@"D:\PracticeCoding\Exercise\Exercise\Backgrounds\example.jpeg", dataArr);


        //    }

        //    WebClient clients = new WebClient();
        //    Stream stream = clients.OpenRead(externalImageUrl);
        //    Bitmap bitmap;
        //    bitmap = new Bitmap(stream);

        //}

        
        [HttpPost]
        public ActionResult Post([FromBody] GeneratorInstructions instructions)
        {
            var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(instructions.Id);
            var imageUrl = selectedBackgroundImage.Url;
            var userText = instructions.UserText;
            var fontName = instructions.FontName;
            var fontSize = instructions.FontSize;
            

            PointF firstLocation = new PointF(10f, 10f);

            Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font fontType = new Font(fontName, fontSize))
                {
                    graphics.DrawString(userText, fontType, Brushes.Blue, firstLocation);
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
        //[HttpPost]
        //public ActionResult Post([FromBody] GeneratorInstructions instructions)
        //{


        //    var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(instructions.Id);
        //    var imageUrl = selectedBackgroundImage.Url;
        //    var imageName = selectedBackgroundImage.Name;
        //    byte[] b = System.IO.File.ReadAllBytes(imageUrl);
        //    return File(b, "image/jpeg");
        //}


        
    }
}
