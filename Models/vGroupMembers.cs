namespace Security_Principles_Web_API.Models
{
    public class vGroupMembers
    {
        public int groupId { get; set; }
        public int memberId { get; set; }
        public string groupDisplayName { get; set; }
        public string memberDisplayName { get; set; }
        public string memberPrincipleType { get; set; }
    }
}
