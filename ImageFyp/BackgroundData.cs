using ImageFyp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageFyp
{
    public class BackgroundData
    {
        public static BackgroundData Current { get; } = new BackgroundData();

        public List<BackgroundImage> Background { get; set; }

        public BackgroundData()
        {
            Background = new List<BackgroundImage>()
            {
                new BackgroundImage()
                {
                    Id = 1,
                    Name = "Beach",
                    Url = "D:/Development/ImageFypApis/ImageFyp/ImageFyp/Beach.jpg",
                },

                new BackgroundImage()
                {
                    Id = 2,
                    Name = "Mountain",
                    Url = "D:/Development/ImageFypApis/ImageFyp/ImageFyp/Mountain.jpg",
                },

                new BackgroundImage()
                {
                    Id= 3,
                    Name = "London",
                    Url = "D:/Development/ImageFypApis/ImageFyp/ImageFyp/Lodnon.jpg",
                },

                new BackgroundImage()
                {
                    Id = 4,
                    Name = "New York",
                    Url = "D:/Development/ImageFypApis/ImageFyp/ImageFyp/NewYork.jpg",
                }
            };
        }

    }
}
