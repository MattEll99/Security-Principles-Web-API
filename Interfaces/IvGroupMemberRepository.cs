using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Interfaces
{
    public interface IvGroupMemberRepository
    {
        //Get and Read.
        public ICollection<vGroupMembers> GetVGroupMembers(string DbContext);
        public List<vGroupMembers> GetVGroupMembersByGroupName(string groupDisplayName, string DbContext);
    }
}
