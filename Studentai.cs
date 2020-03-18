using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAprograma
{
    class Stud 
    {
        public string v;
        public string p;
        public double egz;

        List<double> pzm;

        public Stud(string vardas, string pavarde)
        {
            v = vardas;
            p = pavarde;
            pzm = new List<double>();
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
    }


    class Studentai
    {
        List<Stud> studentai;

        public Studentai()
        {
            studentai = new List<Stud>();
        }

        public void NuskaitytiIsKonsoles()
        {

        }

    }
}
