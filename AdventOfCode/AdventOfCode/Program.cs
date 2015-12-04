using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);

            }
            Console.WriteLine(FloorNumber);
            Console.ReadKey();
            return 0;
        }
    }
}
