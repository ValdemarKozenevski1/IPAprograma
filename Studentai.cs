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
        Median,
        All
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
                for (int i = 0; i < int.Parse(data[2].Replace("x", "")); i++)
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

        public void AddGrade(double g)
        {
            pzm.Add(g);
        }

        public void SetEgz(double e)
        {
            egz = e;
        }

        public double GetMean()
        {
            if (pzm.Count == 0)
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

            try
            {
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
            finally{}
            return 0;
        }

        public string[] GetData(Stats option)
        {
            var data = new List<string> { p, v };
            if (option == Stats.Mean || option == Stats.All)
            {
                data.Add(GetMean().ToString("0.##"));
            }
            if (option == Stats.Median || option == Stats.All)
            {
                data.Add(GetMedian().ToString("0.##"));
            }
            return data.ToArray();
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

        public static void IvestiStudentuFaila()
        {
            var studentai = new List<Stud>();

            while (true)
            {
                Console.WriteLine("Iveskite kelia i faila");
                var line = Console.ReadLine().Replace("\"", "");

                if (System.IO.File.Exists(line))
                {
                    studentai = NuskaitytiFaila(line);
                    break;
                }
                else
                {
                    Console.WriteLine("Blogas kelias i faila.");
                }
            }

            Lentele.PrintStudentList(studentai, Stats.All);
        }

        public static List<Stud> NuskaitytiFaila(string path)
        {
            var studentai = new List<Stud>();

            foreach (string line in System.IO.File.ReadLines(path).Skip(1))
            {
                studentai.Add(ReadStudent(line));
            }

            return studentai;
        }

        public static Stud ReadStudent(string line)
        {
            var args = line.Split().Where(x => !x.Equals("")).ToArray();
            var stud = new Stud(args[0], args[1]);

            for (int i = 2; i < args.Length - 1; i++)
            {
                stud.AddGrade(double.Parse(args[i]));
            }

            stud.SetEgz(double.Parse(args.Last()));

            return stud;
        }

        public static List<Stud> OrderStudents(List<Stud> studs)
        {
            return studs.OrderBy(x => x.v).ThenByDescending(x => x.p).ToList();
        }
    }
}
