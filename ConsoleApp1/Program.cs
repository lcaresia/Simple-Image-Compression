using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static string path = "C:/Users/Lucas/source/repos/ConsoleApp1/ConsoleApp1/imgs/";
        static string file = "teste.png";
        static string extension = "png";



        static string file_path = path + "test.png";
        static string file_path_temp = path + "temp." + extension;
        static string file_path_best = path + "best." + extension;

        static List<Color> colors = new List<Color>();
        static int max_range_color = 5;
        static int range_saturation = 300;
        static int range_hue = 300;
        static int range_lightness = 300;
        static long size = new FileInfo(file_path).Length;

        static List<Bitmap> images = new List<Bitmap>();

        static int changes = 0;

        static Stopwatch sw = new Stopwatch();

        static Bitmap best_image = new Bitmap(file_path);
        static int best_range = 0;

        static void Main(string[] args)
        {
            sw.Start();

            for(int k = 1; k <= max_range_color; k++)
            {
                Bitmap image = new Bitmap(file_path);

                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        Color pixel = image.GetPixel(i, j);

                        image.SetPixel(i, j, existsColor(pixel, k));
                    }
                }

                images.Add(image);

                best_image.Save(file_path_best);
                image.Save(file_path_temp);

                long temp_length = new FileInfo(file_path_temp).Length;
                long best_length = new FileInfo(file_path_best).Length;

                if (temp_length < best_length)
                {
                    best_image = image;
                    best_range = k;
                }
            }

            sw.Stop();
            TimeSpan time = sw.Elapsed;

            File.Delete(file_path_temp);

            long best_size = new FileInfo(file_path_best).Length;

            long percent = 100 - (best_size / (size / 100));

            Console.WriteLine("O melhor range foi " + best_range+";");
            Console.WriteLine(changes + " cores foram trocadas" + ";");
            Console.WriteLine("A imagem diminuiu em " + percent + "%" + ";");
            Console.WriteLine("Demorou " + time + " para executar" + ".");

            Console.ReadLine();
        }

        static Color existsColor(Color pixel, int range_color)
        {
            foreach (Color color in colors)
            {
                if((pixel.R > color.R- range_color && pixel.R < color.R + range_color) && 
                    (pixel.B > color.B - range_color && pixel.B < color.B + range_color) && 
                    (pixel.G > color.G - range_color && pixel.G < color.G + range_color)/* &&
                    (pixel.GetSaturation() > (color.GetSaturation() - range_saturation) && pixel.GetSaturation() < (color.GetSaturation() + range_saturation)) &&
                    (pixel.GetHue() > (color.GetHue() - range_hue) && pixel.GetHue() < (color.GetHue() + range_hue)) &&
                    (pixel.GetBrightness() > (color.GetBrightness() - range_lightness) && pixel.GetBrightness() < (color.GetBrightness() + range_lightness))*/)
                {
                    changes++;
                    return color;
                }
            }

            colors.Add(pixel);

            return pixel;
        }
    }
}
