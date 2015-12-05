﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                string MET = Console.ReadLine();
                Type RT = typeof(Routine);
                MethodInfo theMethod = RT.GetMethod(MET);
                Routine R = new Routine();
                theMethod.Invoke(R, null);
                
            } while (true);
        }
    }

    public class Routine
    {
        public int Floor()
        {
            int FloorNumber = 0;
            int BasementCharacter = 0;
            bool EnteredBasement = false;
            string input = GetStringFromUrl("https://raw.githubusercontent.com/lunaroyster/AdventOfCode/master/AdventOfCode/Floor");

            for (int i = 0; i <= (input.Length-1); i++)
            {
                switch (input[i].ToString())
                {
                    case "(":
                        FloorNumber += 1;
                        break;
                    case ")":
                        FloorNumber -= 1;
                        break;
                    default:
                        break;
                }
                if (FloorNumber < 0)
                {
                    if (EnteredBasement == false) { BasementCharacter = i+1; EnteredBasement = true; }
                }
                
                Console.WriteLine(FloorNumber);
            }
            Console.WriteLine("The final floor is: " + FloorNumber);
            Console.WriteLine("Basement was entered at: " + BasementCharacter);
            Console.ReadKey();
            return FloorNumber;
        }

        public int Wrap()
        {
            
            int WrapArea = 0;
            string input = GetStringFromUrl("https://raw.githubusercontent.com/lunaroyster/AdventOfCode/master/AdventOfCode/Wrap");
            using (StringReader Reader = new StringReader(input))
            {
                string dimension;
                while ((dimension = Reader.ReadLine()) != null)
                {
                    int x = Convert.ToInt32(dimension.Split('x')[0]);
                    int y = Convert.ToInt32(dimension.Split('x')[1]);
                    int z = Convert.ToInt32(dimension.Split('x')[2]);

                    int SurfaceXY = x * y;
                    int SurfaceYZ = y * z;
                    int SurfaceZX = z * x;

                    int TotalSurfaceArea = 2 * (SurfaceXY + SurfaceYZ + SurfaceZX);

                    int FlapArea = 0;
                    FlapArea = (SurfaceXY < SurfaceYZ ? SurfaceXY : SurfaceYZ) < SurfaceZX ? (SurfaceXY < SurfaceYZ ? SurfaceXY : SurfaceYZ) : SurfaceZX;

                    WrapArea += TotalSurfaceArea + FlapArea;
                    Console.WriteLine(dimension + " " + WrapArea);
                }
            }
            Console.WriteLine("The final Wrap Area is: " + WrapArea);
            Console.ReadKey();
            return WrapArea;
        }

        public string GetStringFromUrl(string url)
        {
            WebClient WC = new WebClient();
            return WC.DownloadString(url);
        }

    }
}
