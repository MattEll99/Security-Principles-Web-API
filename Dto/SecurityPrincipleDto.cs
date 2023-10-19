namespace Security_Principles_Web_API.Dto
{
    public class SecurityPrincipleDto
    {
        public int Id { get; set; }
        public required string applicationId { get; set; }
        public required string principleType { get; set; }
        public required string displayName { get; set; }
    }
}
