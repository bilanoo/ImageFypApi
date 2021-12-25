using ImageFyp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageFyp
{
    public static class BackgroundData
    {
        public static List<BackgroundImage> GetBackgroundImages()
        {
            return ImagesAvailable;
        }

        private static readonly List<BackgroundImage> ImagesAvailable = new List<BackgroundImage>()
        {
            new BackgroundImage()
            {
                Id = 1,
                Name = "Beach",
                Url = @"D:\Development\ImageFypApis\ImageFyp\ImageFyp\Backgrounds\beach.jpg",
            },

            new BackgroundImage()
            {
                Id = 2,
                Name = "Mountain",
                Url = @"D:\Development\ImageFypApis\ImageFyp\ImageFyp\Backgrounds\mountain.jpg",
            },

            new BackgroundImage()
            {
                Id= 3,
                Name = "London",
                Url = @"D:\Development\ImageFypApis\ImageFyp\ImageFyp\Backgrounds\london.jpg",
            },

            new BackgroundImage()
            {
                Id = 4,
                Name = "New York",
                Url = @"D:\Development\ImageFypApis\ImageFyp\ImageFyp\Backgrounds\newyork.jpg",
            }

          
        };

        public static BackgroundImage GetBackgroundImageById (int id)
        {
            var backgroundToReturn = BackgroundData.ImagesAvailable
                .FirstOrDefault(c => c.Id == id);

            if (backgroundToReturn == null)
            {
                return null;
            }

            return backgroundToReturn;
        }

    }
}
