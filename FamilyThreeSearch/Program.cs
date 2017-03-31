using FamilyTreeSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyThreeSearch
{
    public class Program
    {
        public static int Main(string[] argv)
        {
            List<Family> family = new List<Family> {
                    new Family { Parent1 = 1, Parent2 = 2 },
                    new Family { Parent1 = 3, Parent2 = 4 },
                    new Family { Parent1 = 5, Parent2 = 6 }
            };

            var f = (new int[] { 1, 2 }).Intersect(new int[] { 1 });

            return 0;
        }
    }
}
