using FamilyTreeSearch.Model;
using FamilyTreeSearchTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeSearch.Data
{
    public interface IFamilyTreeSearchContext
    {
        MockDbSet<Family> Families { get; }
        MockDbSet<Child> Children { get; }
        int SaveChanges();
    }
}
