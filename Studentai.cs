using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    public enum Stats
    {
        Mean,
        Median
    }

    public class Stud 
    {
        public string v;
        public string p;
        public double egz;
        List<double> pzm = new List<double>();
        public static Random Rnd = new Random();


        public Stud(string args)
        {
            var data = args.Split();

            v = data[0];
            p = data[1];

            if (data[2].StartsWith("x"))
            {
                for(int i = 0; i < int.Parse(data[2].Replace("x", "")); i++)
                {
                    pzm.Add(Rnd.Next(0, 10));
                }
            }
            else
            {
                for (int i = 2; i < data.Length; i++)
                {
                    pzm.Add(double.Parse(data[i]));
                }
            }
        }

        public Stud(string vardas, string pavarde)
        {
            v = vardas;
            p = pavarde;
        }

        public Stud(string vardas, string pavarde, List<double> grades)
        {
            pzm = grades;
        }

        public Stud(string vardas, string pavarde, List<double> grades, double egzGrade) : this(vardas, pavarde, grades)
        {
            egz = egzGrade;
        }

        public double GetMean()
        {
            if(pzm.Count == 0)
            {
                return 0;
            }
            return (double)pzm.Sum() / (double)pzm.Count;
        }

        public double GetMedian()
        {
            double[] temp = pzm.ToArray();
            Array.Sort(temp);
            int count = temp.Length;
            if (count == 0)
            {
                return 0;
            }
            else if (count % 2 == 0)
            {                
                return (temp[count / 2 - 1] + temp[count / 2]) / 2.0;
            }
            else
            {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }

        public string[] GetData(Stats option)
        {
            var data = new string[] { p, v };
            double value = 0;
            if(option == Stats.Mean)
            {
                value = GetMean();
            }
            else if (option == Stats.Median)
            {
                value = GetMedian();
            }
            return data.Append(value.ToString("0.##")).ToArray();
        }
    }

    public static class Studentai
    {        
        public static void IvestiStudentus()
        {
            var studentai = new List<Stud>();

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

                    studentai.Add(new Stud(line));
                }
            }

            Console.WriteLine("Iveskite m (mean) arba me (mediana)");
            line = Console.ReadLine();

            Stats option = Stats.Mean; //1 mean, 2 mediana
            if (line.ToLower().Equals("me"))
            {
                option = Stats.Median;
            }

            Lentele.PrintStudentList(studentai, option);
        }        
    }
}
