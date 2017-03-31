using FamilyTreeSearch.Data;
using FamilyTreeSearch.Interfaces;
using FamilyTreeSearch.Model;
using System.Collections.Generic;
using System.Linq;

namespace FamilyThreeSearch
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly IFamilyTreeSearchContext familyContext = null;
        public FamilyRepository(IFamilyTreeSearchContext context)
        {
            familyContext = context;
        }
        public List<Family> GetFamilies()
        {
            return familyContext.Families.ToList();
        }

        public void Add(Family family)
        {
            familyContext.Families.Add(family);
        }
        public int GetNumberOfAncestors(int id)
        {
            return (familyContext.Families.FirstOrDefault(f => f.Parent1 == id || f.Parent2 == id)?.Children?.Count ?? 0);
        }

        public bool IsImmediateFamily(int id1, int id2)
        {
            bool immediate = false;

            foreach (var family in familyContext.Families)
            {
                var parent1 = family.Parent1 == id1 || family.Parent1 == id2 ? true : false;
                var parent2 = family.Parent2 == id1 || family.Parent2 == id2 ? true : false;

                int count = 0;

                family.Children.ForEach((item) => { count += (item.ChildId == id1 || item.ChildId == id2 ? 1 : 0); });

                immediate = count == 2 ? true : 
                        ((parent1 || parent2) && count == 1 ? true : 
                        ( parent1 && parent2 ? true : false));

                if (immediate) break;
            }

            return immediate;
        }
    }
}
