namespace Security_Principles_Web_API.Dto
{
    public class GroupMemberDto
    {
        public required int groupId { get; set; }
        public required int securityPrincipleId { get; set; }
    }
}
