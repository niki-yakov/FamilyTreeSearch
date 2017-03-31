using FamilyTreeSearch.Model;
using System.Data.Entity;
using FamilyTreeSearchTesting;
using System;

namespace FamilyTreeSearch.Data
{
    public class FamilyTreeSearchContext : IFamilyTreeSearchContext
    {
        public virtual MockDbSet<Family> Families { get; set; }
        public virtual MockDbSet<Child> Children { get; set; }

        public FamilyTreeSearchContext()
        {
            Families = new MockDbSet<Family>();
            Children = new MockDbSet<Child>();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
