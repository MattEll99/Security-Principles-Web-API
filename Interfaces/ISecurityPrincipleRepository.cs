using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Interfaces
{
    public interface ISecurityPrincipleRepository
    {
        //Get And Read.
        ICollection<SecurityPrinciple> GetSecurityPrinciples(string DbContext);
        ICollection<SecurityPrinciple> GetSecurityPrinciplesByType(string type, string DbContext);
        SecurityPrinciple GetSecurityPrincipleById(int id, string DbContext);
        SecurityPrinciple GetSecurityPrincipleByDisplayName(string displayName, string DbContext);

        //Create.
        bool CreateSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext);
        bool Save(string DbContext);

        //Update
        bool UpdateSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext);

        //Delete
        bool DeleteSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext);
        bool DeleteSecurityPrincipleByDisplayName(SecurityPrinciple securityPrinciple, string DbContext);

        //Exists.
        bool SecurityPrincipleExists(int id, string DbContext);
        bool SecurityPrincipleExists(string displayName, string DbContext);
    }
}
