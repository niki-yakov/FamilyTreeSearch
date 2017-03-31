using System;
using System.Collections;
using System.Collections.Generic;

namespace FamilyTreeSearch.Model
{
    public class Family
    {
        public int Id { get; set; }
        public int Parent1 { get; set; }
        public int Parent2 { get; set; }
        public virtual List<Child> Children { get; set; }
    }
}
