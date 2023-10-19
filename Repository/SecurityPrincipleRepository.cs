using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Repository
{
    public class SecurityPrincipleRepository : ISecurityPrincipleRepository
    {
        private readonly DataContext _context;

        public SecurityPrincipleRepository(DataContext context)
        {
            _context = context;
            
        }
        public SecurityPrinciple GetSecurityPrincipleById(int id)
        {
            return _context.SecurityPrinciples.Where(s => s.Id == id).FirstOrDefault();
        }

        public SecurityPrinciple GetSecurityPrincipleByDisplayName(string displayName)
        {
            return _context.SecurityPrinciples.Where(s => s.displayName == displayName).FirstOrDefault();
        }

        public ICollection<SecurityPrinciple> GetSecurityPrinciples()
        {
            return _context.SecurityPrinciples.OrderBy(sp => sp.Id).ToList();
        }

        public bool SecurityPrincipleExists(int id)
        {
            return _context.SecurityPrinciples.Any(sp => sp.Id == id);
        }

        public bool SecurityPrincipleExists(string displayName)
        {
            bool result = _context.SecurityPrinciples.Any(sp => sp.displayName == displayName);
            return _context.SecurityPrinciples.Any(sp => sp.displayName == displayName);
        }

        public ICollection<SecurityPrinciple> GetSecurityPrinciplesByType(string type)
        {
            return _context.SecurityPrinciples.Where(s => s.principleType == type).ToList();
        }

        //Create
        public bool CreateSecurityPrinciple(SecurityPrinciple securityPrinciple)
        {
            _context.Add(securityPrinciple);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Update

        public bool UpdateSecurityPrinciple(SecurityPrinciple securityPrinciple)
        {
            _context.Update(securityPrinciple);
            return Save();
        }

        //Delete
        public bool DeleteSecurityPrinciple(SecurityPrinciple securityPrinciple)
        {
            _context.Remove(securityPrinciple);
            return Save();
        }

        public bool DeleteSecurityPrincipleByDisplayName(SecurityPrinciple securityPrinciple)
        {
            _context.Remove(securityPrinciple);
            return Save();
        }
    }
}
