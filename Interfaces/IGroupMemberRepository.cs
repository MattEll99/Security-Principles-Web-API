using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Interfaces
{
    public interface IGroupMemberRepository
    {
        //Get And Read.
        ICollection<GroupMember> GetAll();
        ICollection<GroupMember> GetGroupMembersByGroupId(int groupId);
        GroupMember GetGroupBySecurityPrincipleId(int securityPrincipleId);

        //Create
        bool CreateGroupMember(GroupMember groupMember);
        bool Save();

        //Delete
        bool DeleteGroupMember(GroupMember groupMember);
    }
}
