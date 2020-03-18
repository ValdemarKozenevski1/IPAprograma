using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    public class StudentaiArr
    {
        public static class StudentaiIsMasyvo
        {
            public static void IvestiStudentus()
            {
                var studentai = new Stud[0];

                string line;
                while (true)
                {
                    Console.WriteLine("Iveskite varda, pavarde ir studento pazymius (ARBA xN kur N yra norimu pazymiu skaicius)");
                    Console.WriteLine("ARBA spauskite enter");

                    line = Console.ReadLine();

                    if (line.Equals(""))
                    {
                        break;
                    }
                    else
                    {
                        var data = line.Split();

                        studentai.Append(new Stud(line));
                    }
                }

                Console.WriteLine("Iveskite m (mean) arba me (mediana)");
                line = Console.ReadLine();

                Stats option = Stats.Mean; //1 mean, 2 mediana
                if (line.ToLower().Equals("me"))
                {
                    option = Stats.Median;
                }

                Lentele.PrintStudentList(studentai.ToList(), option);
            }
        }

    }
}
