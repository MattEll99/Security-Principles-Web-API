using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Interfaces
{
    public interface ISecurityPrincipleRepository
    {
        //Get And Read.
        ICollection<SecurityPrinciple> GetSecurityPrinciples();
        ICollection<SecurityPrinciple> GetSecurityPrinciplesByType(string type);
        SecurityPrinciple GetSecurityPrincipleById(int id);
        SecurityPrinciple GetSecurityPrincipleByDisplayName(string displayName);

        //Create.
        bool CreateSecurityPrinciple(SecurityPrinciple securityPrinciple);
        bool Save();

        //Update
        bool UpdateSecurityPrinciple(SecurityPrinciple securityPrinciple);

        //Delete
        bool DeleteSecurityPrinciple(SecurityPrinciple securityPrinciple);
        bool DeleteSecurityPrincipleByDisplayName(SecurityPrinciple securityPrinciple);

        //Exists.
        bool SecurityPrincipleExists(int id);
        bool SecurityPrincipleExists(string displayName);
    }
}
