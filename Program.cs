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
                Console.WriteLine("E. Baigti programa");

                var line = Console.ReadLine();

                if (line.Equals("1"))
                {
                    //Studentai.IvestiStudentus();
                    StudentaiArr.StudentaiIsMasyvo.IvestiStudentus();
                }

                if (line.Equals("E"))
                {
                    break;
                }
            }
        }
    }
}
