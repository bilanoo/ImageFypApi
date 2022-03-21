using ImageFyp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImageFyp
{
    public class AvailableFonts
    {
        public static List<Fonts> GetAvailableFonts()
        {
            return FontsAvailable;
        }

        // top 10 most used fonts
        private static readonly List<Fonts> FontsAvailable = new List<Fonts>()
        {
            new Fonts()
            {
                Name = "Arial",
            },
            new Fonts()
            {
                Name = "Helvetica",
            },
            new Fonts()
            {
                Name = "Calibri",
            },
            new Fonts()
            {
                Name = "Futura",
            },
            new Fonts()
            {
                Name = "Garamond",
            },
            new Fonts()
            {
                Name = "Times New Roman"
            },
            new Fonts()
            {
                Name = "Cambria",
            },
            new Fonts()
            {
                Name = "Verdana",
            },
            new Fonts()
            {
                Name = "Rockwell",
            },
            new Fonts()
            {
                Name = "Franklin Gothic",
            }

        };
    }
}
