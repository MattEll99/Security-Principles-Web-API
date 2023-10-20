using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;
using System.Linq;

namespace Security_Principles_Web_API.Repository
{
    public class vGroupMembersRepository : RepositoryBase, IvGroupMemberRepository
    {
        public vGroupMembersRepository(DataContext Scontext, TDataContext Tcontext) : base(Scontext, Tcontext)
        {

        }
        public ICollection<vGroupMembers> GetVGroupMembers(string DbContext)
        {
           
            return GetDbContext(DbContext).VGroups.ToList();

            throw new NotImplementedException();
        }

        public List<vGroupMembers> GetVGroupMembersByGroupName(string groupDisplayName, string DbContext)
        {
            return GetDbContext(DbContext).VGroups.Where(gdn => gdn.groupDisplayName == groupDisplayName).ToList();
            throw new NotImplementedException();
        }
    }
}
