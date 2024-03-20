using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2
{
    public class Student
    {
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Kierunek { get; set; }
        public string Tryb { get; set; }

        public int NrIndeksu { get; set; }
        public DateOnly Data { get; set; }
        public string Email { get; set; }
        public string ImieMatki { get; set; }
        public string ImieOjca { get; set; }
    }
}
