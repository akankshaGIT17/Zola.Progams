using Microsoft.EntityFrameworkCore;
using NMemory.Indexes;
using NMemory.Tables;
using NMemory;
using Zola.Web.Models;

namespace Zola.Web.Controllers
{
    public class PharmaDbContext: Database
    {
        public PharmaDbContext()
        {
            //install NMemory nuget from the package manager.

            var members = this.Tables.Create<Medicines, long>(x =>x.Id);
            //var groups = base.Tables.Create<Group, int>(g => g.Id);

            this.Medicines = members;
         //   this.Groups = groups;

            RelationOptions options = new RelationOptions(
                cascadedDeletion: true);

            var peopleGroupIdIndex = members.CreateIndex(
                new RedBlackTreeIndexFactory(),
                p => p.Id);
            //Below line creates a relation
            //this.Tables.CreateRelation(
            //    Medicines.PrimaryKeyIndex,
            //    peopleGroupIdIndex,
            //    x => x==0? -1:0,
            //    x => x,
            //    options);
        }

        public ITable<Medicines> Medicines { get; private set; }

//        public ITable<Group> Groups { get; private set; }

    }
}