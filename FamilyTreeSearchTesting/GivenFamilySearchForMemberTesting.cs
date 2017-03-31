using Moq;
using FamilyTreeSearch.Model;
using FamilyTreeSearch.Data;
using FamilyThreeSearch;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Data.Entity;

namespace FamilyTreeSearchTesting
{
    public class GivenFamilySearchForMemberTesting
    {
        FamilyRepository service = null;
        List <Family> families = null;
        FamilyTreeSearchContext mockContext = null;
        public GivenFamilySearchForMemberTesting()
        {
            families = new List<Family>
            {
                new Family
                {
                    Parent1 = 1,
                    Parent2 = 2,
                    Children = new List<Child>
                    {
                        new Child
                        {
                            ChildId = 3,
                        },
                        new Child
                        {
                            ChildId = 4
                        },
                        new Child
                        {
                            ChildId = 5
                        }
                    }
                },
                new Family
                {
                    Parent1 = 5,
                    Parent2 = 6,
                    Children = new List<Child>
                    {
                        new Child
                        {
                            ChildId = 7
                        },
                        new Child
                        {
                            ChildId = 8
                        },
                        new Child
                        {
                            ChildId = 9
                        }
                    }
                }
            };

            mockContext = new FamilyTreeSearchContext();

            mockContext.Families.Add(families[0]);
            mockContext.Families.Add(families[1]);

            service = new FamilyRepository(mockContext);
        }
        [Fact]
        public void GivenFamilyListRetrieveNumbuerOfFamilies()
        {
            var familyCount = service.GetFamilies().Count;

            Assert.Equal(2, familyCount);
        }
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        public void GievnFamilyListRetrieveNumberOfAncestore(int id, int expectedNumber)
        {
            var familyCount = service.GetNumberOfAncestors(id);

            Assert.Equal(expectedNumber, familyCount);
        }
        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(2, 3, true)]
        [InlineData(1, 4, true)]
        [InlineData(1, 6, false)]
        [InlineData(5, 6, true)]
        [InlineData(8, 9, true)]
        public void GievnFamilyListIsImmediateFamilyMember(int id1, int id2, bool expected)
        {
            var familyCount = service.IsImmediateFamily(id1, id2);

            Assert.Equal(expected, familyCount);
        }
    }
}
