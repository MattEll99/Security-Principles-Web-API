using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Security_Principles_Web_API.Dto;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;
using Security_Principles_Web_API.Repository;

namespace Security_Principles_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IMapper _mapper;

        public GroupMemberController(IGroupMemberRepository groupMemberRepository, IMapper mapper)
        {
            _groupMemberRepository = groupMemberRepository;
            _mapper = mapper;
        }


        //Get and Read.

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupMember>))]
        public IActionResult GetAll()
        {
            var groupmembers = _groupMemberRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupmembers);
        }

        [HttpGet("{{groupId}}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupMember>))]
        public IActionResult GetGroupMembersByGroupId([FromQuery] int groupId)
        {
            var groupmembers = _groupMemberRepository.GetGroupMembersByGroupId(groupId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupmembers);
        }

        [HttpGet("{{securityPrincipleId}}")]
        [ProducesResponseType(200, Type = typeof(GroupMember))]
        public IActionResult GetGroupBySecurityPrincipleId([FromQuery] int securityPrincipleId)
        {
            var groupId = _groupMemberRepository.GetGroupBySecurityPrincipleId(securityPrincipleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupId);
        }

        //Create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGroupMember([FromQuery] GroupMember groupMemberCreate)
        {
            if (groupMemberCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var groupMemberMap = _mapper.Map<GroupMember>(groupMemberCreate);

            if (!_groupMemberRepository.CreateGroupMember(groupMemberMap))
            {
                ModelState.AddModelError("", "Something went wrong when saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //Delete

        [HttpDelete("DeleteGroupMember")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGroupMember([FromQuery]int groupId, [FromQuery]int securityPrincipleId)
        {
            var groupMemberToDelete = _groupMemberRepository.GetGroupMembersByGroupId(groupId).Where(sp => sp.securityPrincipleId == securityPrincipleId).FirstOrDefault();

            if (!_groupMemberRepository.DeleteGroupMember(groupMemberToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();

        }
    }
}
