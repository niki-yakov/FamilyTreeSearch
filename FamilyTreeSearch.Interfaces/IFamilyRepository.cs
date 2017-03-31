using FamilyTreeSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeSearch.Interfaces
{
    public interface IFamilyRepository
    {
        List<Family> GetFamilies();
        int GetNumberOfAncestors(int id);
        bool IsImmediateFamily(int id1, int id2);
    }
}
