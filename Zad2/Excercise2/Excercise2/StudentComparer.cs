﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x == null || y == null) return false;

            return (x.Imie == y.Imie)
                && (x.Nazwisko == y.Nazwisko)
                && (x.NrIndeksu == y.NrIndeksu);
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.NrIndeksu.GetHashCode();
        }
    }
}
