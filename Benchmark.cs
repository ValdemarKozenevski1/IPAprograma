﻿using System;
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
                data.AddRange(FormatTimeSpans(times));
                System.Console.WriteLine(Lentele.GetFormatRow(false, data.ToArray()));
            }
        }

        public static List<TimeSpan> ExecuteBencmark(int n)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var stud = new List<Stud>();
            for (int i = 0; i < n; i++)
            {
                stud.Add(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var v = new List<Stud>();
            var k = new List<Stud>();
            for (int i = 0; i < n; i++)
            {
                if (stud[i].GetMean() < 5)
                {
                    v.Add(stud[i]);
                }
                else
                {
                    k.Add(stud[i]);
                }
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            v = Studentai.OrderStudents(v).ToList();
            k = Studentai.OrderStudents(k).ToList();

            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, v);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);
            sw.Restart();

            path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, k);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }

        public static void RunContainerBenchmark(int size)
        {
            Lentele.tableWidth = 80;

            System.Console.WriteLine($"Student list size: {size}");
            System.Console.WriteLine(Lentele.GetFormatRow(false, "Container", "Init", "Split", "Sort", "Write"));
            System.Console.WriteLine(Lentele.GetLine());

            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestList(size)).Prepend("List").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestLinkedListLast(size)).Prepend("LinkedList").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestQueueElementAt(size)).Prepend("Queue").ToArray()));
        }

        public static string[] FormatTimeSpans(List<TimeSpan> times)
        {
            return times.Select(x => string.Format("{0}:{1:D2}.{2}", (int)x.TotalMinutes, x.Seconds, x.Milliseconds)).ToArray();
        }

        public static List<TimeSpan> TestList(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new List<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.Add(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new List<Stud>();
            var b = new List<Stud>();
            for (int i = 0; i < size; i++)
            {
                if(container[i].GetMean() < 5)
                {
                    a.Add(container[i]);
                }
                else
                {
                    b.Add(container[i]);
                }
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            a = Studentai.OrderStudents(a).ToList();
            b = Studentai.OrderStudents(b).ToList();

            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);
            sw.Restart();

            return times;
        }

        public static List<TimeSpan> TestLinkedListFirst(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new LinkedList<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.AddFirst(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new LinkedList<Stud>();
            var b = new LinkedList<Stud>();
            for (int i = 0; i < size; i++)
            {
                var element = container.First();
                if (element.GetMean() < 5)
                {
                    a.AddFirst(element);
                }
                else
                {
                    b.AddFirst(element);
                }
                container.RemoveFirst();
            }

            times.Add(sw.Elapsed);
            sw.Restart();
            a = new LinkedList<Stud>(Studentai.OrderStudents(a));
            b = new LinkedList<Stud>(Studentai.OrderStudents(b));            
            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }

        public static List<TimeSpan> TestQueue(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new Queue<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.Enqueue(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new Queue<Stud>();
            var b = new Queue<Stud>();
            for (int i = 0; i < size; i++)
            {
                var element = container.Dequeue();

                if (element.GetMean() < 5)
                {
                    a.Enqueue(element);
                }
                else
                {
                    b.Enqueue(element);
                }
            }

            times.Add(sw.Elapsed);
            sw.Restart();
            a = new Queue<Stud>(Studentai.OrderStudents(a));
            b = new Queue<Stud>(Studentai.OrderStudents(b));
            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }

        public static List<TimeSpan> TestListDel(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new List<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.Add(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new List<Stud>();
            var b = new List<Stud>();
            for (int i = size-1; i >= 0; i--)
            {
                if (container[i].GetMean() < 5)
                {
                    a.Add(container[i]);
                }
                else
                {
                    b.Add(container[i]);
                }
                container.RemoveAt(i);
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            a = Studentai.OrderStudents(a).ToList();
            b = Studentai.OrderStudents(b).ToList();

            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);
            sw.Restart();

            return times;
        }

        public static List<TimeSpan> TestLinkedListLast(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new LinkedList<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.AddLast(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new LinkedList<Stud>();
            var b = new LinkedList<Stud>();
            for (int i = 0; i < size; i++)
            {
                var element = container.Last();
                if (element.GetMean() < 5)
                {
                    a.AddLast(element);
                }
                else
                {
                    b.AddLast(element);
                }
                container.RemoveLast();
            }

            times.Add(sw.Elapsed);
            sw.Restart();
            a = new LinkedList<Stud>(Studentai.OrderStudents(a));
            b = new LinkedList<Stud>(Studentai.OrderStudents(b));
            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }

        public static List<TimeSpan> TestQueueElementAt(int size)
        {
            var times = new List<TimeSpan>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var container = new Queue<Stud>();
            for (int i = 0; i < size; i++)
            {
                container.Enqueue(new Stud($"Vardas{i} Pavarde{i} x5"));
            }

            times.Add(sw.Elapsed);
            sw.Restart();

            var a = new Queue<Stud>();
            var b = new Queue<Stud>();
            for (int i = 0; i < size; i++)
            {
                var element = container.ElementAt(i);
                if (element.GetMean() < 5)
                {
                    a.Append(element);
                }
                else
                {
                    b.Append(element);
                }
            }

            times.Add(sw.Elapsed);
            sw.Restart();
            a = new Queue<Stud>(Studentai.OrderStudents(a));
            b = new Queue<Stud>(Studentai.OrderStudents(b));
            times.Add(sw.Elapsed);
            sw.Restart();

            string path = System.IO.Path.GetTempFileName();
            Studentai.WriteStudents(path, container);
            System.IO.File.Delete(path);

            times.Add(sw.Elapsed);

            return times;
        }

        public static void RunAdvanceBenchmark(int size)
        {
            Lentele.tableWidth = 100;

            System.Console.WriteLine($"Student list size: {size}");
            System.Console.WriteLine(Lentele.GetFormatRow(false, "Strategy", "Init", "Split", "Sort", "Write"));
            System.Console.WriteLine(Lentele.GetLine());

            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestList(size)).Prepend("List/NoDel").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestListDel(size)).Prepend("List/WithDel").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestLinkedListFirst(size)).Prepend("LinkedList/DelFirst").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestLinkedListLast(size)).Prepend("LinkedList/DelLast").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestQueue(size)).Prepend("Queue/First").ToArray()));
            System.Console.WriteLine(Lentele.GetFormatRow(false, FormatTimeSpans(TestQueueElementAt(size)).Prepend("Queue/ElementAt").ToArray()));
        }
    }
}
