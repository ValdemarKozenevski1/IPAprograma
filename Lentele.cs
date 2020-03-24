using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    public class Lentele
    {
        public static int tableWidth = 80;

        public static void PrintStudentList(List<Stud> studentai, Stats option)
        {
            try
            {
                var temp = Studentai.OrderStudents(studentai);
                studentai = temp;
            }
            finally { }

            PrintLine();
            var row = new string[] { "Pavarde", "Vardas" };
            if (option == Stats.Mean || option == Stats.All)
            {
                row = row.Append("Galutinis (Vid.)").ToArray();
            }
            if (option == Stats.Median || option == Stats.All)
            {
                row = row.Append("Galutinis (Med.)").ToArray();
            }

            PrintRow(row);
            PrintLine();
            foreach (var stud in studentai)
            {
                PrintRow(stud.GetData(option));
                //PrintLine();
            }
        }

        public static void PrintLine()
        {
            Console.WriteLine(GetLine());
        }

        public static string GetLine()
        {
            return new string('-', tableWidth);
        }

        public static void PrintRow(params string[] columns)
        {
            Console.WriteLine(GetFormatRow(true, columns));
        }

        public static string GetFormatRow(bool withSeparator, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "";

            if (withSeparator)
            {
                row += "|";
            }

            foreach (string column in columns)
            {
                row += AlignCentre(column, width);

                if (withSeparator)
                {
                    row += "|";
                }
            }

            return row;
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
