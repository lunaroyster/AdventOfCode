using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                try
                {
                    string MET = Console.ReadLine();
                    Type RT = typeof(Routine);
                    MethodInfo theMethod = RT.GetMethod(MET);
                    Routine R = new Routine();
                    theMethod.Invoke(R, null);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

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
            int TotalRibbonPerimeter = 0;
            int TotalRibbonBow = 0;
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
                    FlapArea = SmallestOfTheThree(SurfaceXY, SurfaceYZ, SurfaceZX);

                    int RibbonPerimeter = (2 * ((x + y + z) - LargestOfTheThree(x, y, z)));
                    int RibbonBow = (x*y*z);
                    TotalRibbonPerimeter += RibbonPerimeter;
                    TotalRibbonBow += RibbonBow;
                    WrapArea += TotalSurfaceArea + FlapArea;
                    
                    Console.WriteLine(dimension + "   \t" + (TotalSurfaceArea + FlapArea) + "   \t" + (RibbonBow + RibbonPerimeter));
                }
            }
            Console.WriteLine("The final Wrap Area is: " + WrapArea);
            Console.WriteLine("Total Ribbon Length is: " + (TotalRibbonBow + TotalRibbonPerimeter));
            Console.ReadKey();
            return WrapArea;
        }

        public int Roam()
        {
            int EndowedHouses = 0;
            string input = GetStringFromUrl("https://raw.githubusercontent.com/lunaroyster/AdventOfCode/master/AdventOfCode/Roam");

            for (int i = 0; i <= (input.Length - 1); i++)
            {
                Console.WriteLine(input[i].ToString());
                

            }
                //get the req variables
                //loop through the string
                //move and deliver in each required variable
                //count the number of variables which are not equal to 0
                return EndowedHouses;
        }

        public string Hash()
        {
            string OutputRaw = null;
            string OutputHash = null;

            Console.WriteLine("Input letters");
            string input = Console.ReadLine();

            Console.WriteLine("Hash Mask");
            string mask = Console.ReadLine();

            Console.WriteLine(input + mask + mask.Length.ToString());
            Console.ReadLine();
            for (uint i = 0; i<uint.MaxValue; i++)
            {
                string raw = input + i.ToString();
                string hash = GetMD5(raw);
                //Console.WriteLine(raw + ": " + hash);
                if (hash.Substring(0, mask.Length) == mask)
                {
                    OutputRaw = raw;
                    OutputHash = hash;
                    
                    break;
                }                
            }
            Console.WriteLine("Answer: " + OutputRaw + " " + OutputHash);
            return OutputRaw;
        }

        public int String()
        {
            int NiceStringCount = 0;
            string input = GetStringFromUrl("https://raw.githubusercontent.com/lunaroyster/AdventOfCode/master/AdventOfCode/String");
            //string input = "ahbbeio"; //debug input
            using (StringReader Reader = new StringReader(input))
            {
                string CurrentString;
                while ((CurrentString = Reader.ReadLine()) != null)
                {
                    bool VovelTest = false, RepeatLetterTest = false, NoDisallowedStringTest = true;
                    int VovelCount = 0;
                    for (int i = 0; i < (CurrentString.Length - 1); i++)
                    {
                        //Repeat Letter Test
                        char C = CurrentString[i];
                        string ConcString = CurrentString[i].ToString() + CurrentString[i + 1].ToString();
                        if (ConcString[0] == ConcString[1]) { RepeatLetterTest = true; } 
                        if (ConcString == "ab" || ConcString == "cd" || ConcString == "pq" || ConcString == "xy") { NoDisallowedStringTest = false; } 
                        if (IsVovel(C)) { VovelCount++; }   
                                     
                    }
                    if (IsVovel(CurrentString[CurrentString.Length - 1])) { VovelCount++; }
                    if (VovelCount >= 3) { VovelTest = true; }

                    if (VovelTest == true && RepeatLetterTest == true && NoDisallowedStringTest == true) { NiceStringCount++; }
                    Console.WriteLine(VovelCount.ToString());
                }
                Console.WriteLine(NiceStringCount);
            }

                return NiceStringCount;
        }

        public bool IsVovel(Char C)
        {
            if (C == 'a' || C == 'e' || C == 'i' || C == 'o' || C == 'u')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Bye()
        {
            Console.WriteLine("Really?");
            if (Console.ReadLine() == "ja") { Application.Exit(); }
            return 0;
        }

        public string GetMD5(string input)
        {
            using (MD5 gen = MD5.Create())
            {
                byte[] data = gen.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder SBHash = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    SBHash.Append(data[i].ToString("x2"));
                }
                return SBHash.ToString();
            }
        }

        public string GetStringFromUrl(string url)
        {
            WebClient WC = new WebClient();
            return WC.DownloadString(url);
        }

        public int SmallestOfTheThree(int x, int y, int z)
        {
            int SubSmallest = (x < y ? x : y);
            int Smallest = SubSmallest < z ? SubSmallest : z;
            return Smallest;
        }
        
        public int LargestOfTheThree(int x, int y, int z)
        {
            int SubLargest = (x > y ? x : y);
            int Largest = SubLargest > z ? SubLargest : z;
            return Largest;
        }

    }
}
