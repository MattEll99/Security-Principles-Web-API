using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vGroupMemberController : ControllerBase
    {
        private readonly DataContext _context;
        public vGroupMemberController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetVGroupMembers")]
        public IActionResult GetVGroupMembers()
        {
            var items = _context
                           .VGroups
                           .Select(x => new
                           {
                               gId = x.groupId,
                               mId = x.memberId,
                               gName = x.groupDisplayName,
                               mName = x.memberDisplayName,
                               mPType = x.memberPrincipleType
                           });
            return Ok(items);
        }

        [HttpGet("GetVGroupMembersByGroupName")]
        public IActionResult GetVGroupMembersByGroupName(string groupDisplayName)
        {
            var items = _context
                           .VGroups
                           .Where(gdn => gdn.groupDisplayName == groupDisplayName)
                           .Select(x => new
                           {
                               groupId = x.groupId,
                               memberId = x.memberId,
                               groupDisplayName = x.groupDisplayName,
                               memberDisplayName = x.memberDisplayName,
                               memberPrincipleType = x.memberPrincipleType
                           }
                           );
            return Ok(items);
        }
    }
}
