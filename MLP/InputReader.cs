using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MLP
{
    class InputReader
    {
        public List<List<double>> ReadIrisData(string filePath)
        {

            List<List<double>> listOfInputs = new List<List<double>>();
            for (int i = 0; i < 150; i++)
            {
                listOfInputs.Add(new List<double>());
                for (int j = 0; j < 4; j++)
                {
                    listOfInputs[i].Add(0);
                }
            }
             string s;
             StreamReader file = new StreamReader(filePath);
             int c = 0;
             while((s=file.ReadLine())!=null)
             {
                 if (c == 0)
                 {
                     c++;
                 }
                 else
                 {
                     string[] lol = s.Split(',');
                     listOfInputs[c - 1][0]=(double.Parse(lol[0]));
                     listOfInputs[c - 1][1]=(double.Parse(lol[1]));
                     listOfInputs[c - 1][2]=(double.Parse(lol[2]));
                     listOfInputs[c - 1][3]=(double.Parse(lol[3]));
                     c++;
                 }
             }
             return listOfInputs;
        }
        public List<List<double>> ReadImageData(string[] filepaths)
        {
            List<Bitmap> images = new List<Bitmap>();
            foreach (string s in filepaths)
            {
                images.Add(new Bitmap(s));
            }
            List<List<double>> List_of_Pixel = new List<List<double>>();
            List<double> templist = new List<double>();

            for (int i = 0; i < images.Count; i++)
            {
                for (int l = 0; l < images[i].Width; l++)
                {
                    for (int k = 0; k < images[i].Height; k++)
                    {
                        Color pixelColor = images[i].GetPixel(l, k);
                        double avg = (Convert.ToDouble(pixelColor.R) + Convert.ToDouble(pixelColor.G) + Convert.ToDouble(pixelColor.B)) / 3;
                        templist.Add(avg);
                    }
                }
                List_of_Pixel.Add(new List<double>(templist));
                templist.Clear();
            }
            return List_of_Pixel;
        }
    }
}
