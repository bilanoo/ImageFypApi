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
        // GET: Generator
        //[HttpGet("{id}/{userText}")]
        //public ActionResult GetGenerator(int id, string userText)
        //{


        //    var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(id);
        //    var imageUrl = selectedBackgroundImage.Url;

        //    PointF firstLocation = new PointF(10f, 10f);

        //    Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font arialFont = new Font("Arial", 100))
        //        {
        //            graphics.DrawString(userText, arialFont, Brushes.Blue, firstLocation);
        //        }

        //    }

        //    using (var stream = new MemoryStream())
        //    {
        //        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        return File(stream.ToArray(), "image/jpeg");
        //    }



        //}
        
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

            PointF firstLocation = new PointF(10f, 10f);

            Bitmap bitmap2 = new Bitmap(bitmap);

            using (Graphics graphics = Graphics.FromImage(bitmap2))
            {
                using (Font fontType = new Font(instructions.FontName, instructions.FontSize))
                {
                    
                    graphics.DrawString(instructions.UserText, fontType, Brushes.Blue, firstLocation);
                }

            }

            using (var stream = new MemoryStream())
            {
                bitmap2.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return File(stream.ToArray(), "image/png");
            }
        }

        //[HttpPost]
        //public ActionResult AddTextToBackgroundImage([FromBody] GeneratorInstructions instructions)
        //{
        //    var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(instructions.Id);
        //    var imageUrl = selectedBackgroundImage.Url;
        //    var userText = instructions.UserText;
        //    var fontName = instructions.FontName;
        //    var fontSize = instructions.FontSize;


        //    PointF firstLocation = new PointF(10f, 10f);

        //    Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font fontType = new Font(fontName, fontSize))
        //        {
        //            graphics.DrawString(userText, fontType, Brushes.Blue, firstLocation);
        //        }

        //    }

        //    using (var stream = new MemoryStream())
        //    {
        //        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        return File(stream.ToArray(), "image/jpeg");
        //    }
        //}

        //[HttpPost]
        //public ActionResult Post([FromBody] GeneratorInstructions instructions)
        //{
        //    var selectedBackgroundImage = BackgroundData.GetBackgroundImageById(instructions.Id);
        //    var imageUrl = selectedBackgroundImage.Url;
        //    var userText = instructions.UserText;

        //    PointF firstLocation = new PointF(10f, 10f);

        //    Bitmap bitmap = (Bitmap)Image.FromFile(imageUrl);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font arialFont = new Font("Arial", 300))
        //        {
        //            graphics.DrawString(userText, arialFont, Brushes.Blue, firstLocation);
        //        }

        //    }

        //    using (var stream = new MemoryStream())
        //    {
        //        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        return File(stream.ToArray(), "image/jpeg");
        //    }
        //}


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
