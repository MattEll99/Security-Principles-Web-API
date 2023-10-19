using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Repository
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly DataContext _context;

        public GroupMemberRepository(DataContext context)
        {
            _context = context;            
        }

        //Get And Read
        public ICollection<GroupMember> GetAll()
        {
            return _context.GroupMembers.ToList();
        }

        public ICollection<GroupMember> GetGroupMembersByGroupId(int groupId)
        {
            return _context.GroupMembers.Where(gm => gm.groupId == groupId).ToList();
        }

        public GroupMember GetGroupBySecurityPrincipleId(int securityPrincipleId)
        {
            return _context.GroupMembers.Where(gm => gm.securityPrincipleId == securityPrincipleId).FirstOrDefault();
        }

        //Create
        public bool CreateGroupMember(GroupMember groupMember)
        {
            _context.Add(groupMember);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Delete
        public bool DeleteGroupMember(GroupMember groupMember)
        {
            _context.Remove(groupMember);
            return Save();
        }
    }
}
