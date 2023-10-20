using Microsoft.EntityFrameworkCore;
using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Repository
{
    public class GroupMemberRepository :RepositoryBase, IGroupMemberRepository
    {
        public GroupMemberRepository(DataContext Scontext, TDataContext Tcontext) : base(Scontext, Tcontext)
        {

        }

        //Get And Read
        public ICollection<GroupMember> GetAll(string DbContext)
        {
            return GetDbContext(DbContext).GroupMembers.ToList();
        }

        public ICollection<GroupMember> GetGroupMembersByGroupId(int groupId, string DbContext)
        {
            return GetDbContext(DbContext).GroupMembers.Where(gm => gm.groupId == groupId).ToList();
        }

        public ICollection<GroupMember> GetGroupsBySecurityPrincipleId(int securityPrincipleId, string DbContext)
        {
            return GetDbContext(DbContext).GroupMembers.Where(gm => gm.securityPrincipleId == securityPrincipleId).ToList();
        }

        //Create
        public bool CreateGroupMember(GroupMember groupMember, string DbContext)
        {
            GetDbContext(DbContext).Add(groupMember);
            return Save(DbContext);
        }
        public bool Save(string DbContext)
        {
            var saved = GetDbContext(DbContext).SaveChanges();
            return saved > 0 ? true : false;
        }

        //Delete
        public bool DeleteGroupMember(GroupMember groupMember, string DbContext)
        {
            GetDbContext(DbContext).Remove(groupMember);
            return Save(DbContext);
        }
    }
}
