using Microsoft.EntityFrameworkCore;

namespace Security_Principles_Web_API.Models
{
    public class SecurityPrinciple
    {
        public int Id { get; set; }
        public string applicationId { get; set; }
        public string principleType { get; set; }
        public string displayName { get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}
