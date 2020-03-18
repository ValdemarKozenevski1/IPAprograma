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
    }


    class Studentai
    {


        public Studentai()
        {

        }

    }
}
