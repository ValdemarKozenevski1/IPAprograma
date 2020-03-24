using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    class Benchmark
    {
        public static void RunBenchmark()
        {
            Lentele.tableWidth = 80;

            var sizes = new List<int>() { 1000, 10000, 100000, 1000000, 10000000 };

            System.Console.WriteLine(Lentele.GetFormatRow(false, "Stud sk", "Init", "Split", "Sort", "Write #1", "Write #2"));
            System.Console.WriteLine(Lentele.GetLine());
            foreach (var i in sizes)
            {
                var times = ExecuteBencmark(i);

                var data = new List<string>() { $"{i}" };
                data.AddRange(times.Select(x => string.Format("{0}:{1:D2}.{2}", (int)x.TotalMinutes, x.Seconds, x.Milliseconds)));
                System.Console.WriteLine(Lentele.GetFormatRow(false, data.ToArray()));
            }
        }

        public static List<TimeSpan> ExecuteBencmark(int n)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var stud = new List<Stud>();
            for(int i = 0; i <n; i++)
            {
                stud.Add(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);

            var v = new List<Stud>();
            var k = new List<Stud>();
            for (int i = 0; i < n; i++)
            {
                if(stud[i].GetMean() < 5)
                {
                    v.Add(stud[i]);
                }
                else
                {
                    k.Add(stud[i]);
                }
            }

            times.Add(sw.Elapsed);

            v = Studentai.OrderStudents(v);
            k = Studentai.OrderStudents(k);

            times.Add(sw.Elapsed);

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, v);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, k);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }
    }
}
