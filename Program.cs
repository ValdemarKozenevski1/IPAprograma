using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Iveskite funkcijos numeri (ir spauskite enter):");
                Console.WriteLine("1. Ivesite studentu duomenis");
                Console.WriteLine("2. Ivesite duomenu faila");
                Console.WriteLine("3. Atlikti benchmark'a");
                Console.WriteLine("4. Atlikti konteineriu benchmark'a");
                Console.WriteLine("E. Baigti programa");

                var line = Console.ReadLine();

                if (line.Equals("1"))
                {
                    Studentai.IvestiStudentus();
                }
                if (line.Equals("2"))
                {
                    Studentai.IvestiStudentuFaila();
                }
                if (line.Equals("3"))
                {
                    Benchmark.RunBenchmark();
                }
                if (line.Equals("4"))
                {
                    Benchmark.RunContainerBenchmark();
                }
                if (line.ToLower().Equals("e"))
                {
                    break;
                }
            }
        }
    }
}
