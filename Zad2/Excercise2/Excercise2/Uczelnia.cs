using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2
{
    public class Uczelnia
    {
        public DateOnly createdAt { get; set; }
        public string author { get; set; } = null!;
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<ActiveStudies> activeStudies { get; set;}
    }
}
