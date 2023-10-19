using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Security_Principles_Web_API.Models
{
    public class GroupMember
    {

        public int groupId {  get; set; }
        public int securityPrincipleId { get; set; }
        [ForeignKey("groupId")]
        public SecurityPrinciple Securityprinciple { get; set; }

    }
}
