using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Dto;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityPrincipleController : Controller
    {
        private readonly ISecurityPrincipleRepository _securityPrincipleRepository;
        private readonly IMapper _mapper;

        public SecurityPrincipleController(ISecurityPrincipleRepository securityPrincipleRepository, IMapper mapper)
        {
            _securityPrincipleRepository = securityPrincipleRepository;
            _mapper = mapper;
        }

        [HttpGet("GetSecurityPrinciples")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SecurityPrinciple>))]
        public IActionResult GetSecurityPrinciples(string DbContext)
        {
            var securityPrinciples = _mapper.Map<List<SecurityPrincipleDto>>(_securityPrincipleRepository.GetSecurityPrinciples(DbContext));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciples);
        }

        [HttpGet("GetSecurityPrincipleById")]
        [ProducesResponseType(200, Type = typeof(SecurityPrinciple))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrincipleById([FromQuery] int id, string DbContext)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(id, DbContext))
                return NotFound();

            var securityPrinciple = _mapper.Map<SecurityPrincipleDto>(_securityPrincipleRepository.GetSecurityPrincipleById(id, DbContext));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciple);
        }

        [HttpGet("GetSecurityPrincipleByDisplayName")]
        [ProducesResponseType(200, Type = typeof(SecurityPrinciple))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrincipleByDisplayName([FromQuery] string displayName, string DbContext)
        {
            var securityPrinciple = _mapper.Map<SecurityPrincipleDto>(_securityPrincipleRepository.GetSecurityPrincipleByDisplayName(displayName, DbContext));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciple);
        }

        [HttpGet("GetSecurityPrincipleByType")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SecurityPrinciple>))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrinciplesByType([FromQuery] string principleType, string DbContext)
        {
            var securityPrinciples = _securityPrincipleRepository.GetSecurityPrinciplesByType(principleType, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciples);
        }

        //Create.

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSecurityPrinciple([FromBody] SecurityPrincipleDto securityPrincipleCreate, string DbContext)
        {
            if (securityPrincipleCreate == null)
                return BadRequest(ModelState);

            var securityPrinciple = _securityPrincipleRepository.GetSecurityPrinciples(DbContext)
                .Where(s => s.displayName.Trim().ToUpper() == securityPrincipleCreate.displayName.ToUpper())
                .FirstOrDefault();

            if (securityPrinciple != null)
            {
                ModelState.AddModelError("", "Security Principle already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var securityPrincipleMap = _mapper.Map<SecurityPrinciple>(securityPrincipleCreate);

            if (!_securityPrincipleRepository.CreateSecurityPrinciple(securityPrincipleMap, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong when saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //Update

        [HttpPut("{{displayName}}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSecurityPrinciple(string displayName, [FromBody] SecurityPrincipleDto updatedSecurityPrinciple, string DbContext)
        {
            if (updatedSecurityPrinciple == null)
                return BadRequest(ModelState);

            if (displayName != updatedSecurityPrinciple.displayName)
                return BadRequest(ModelState);

            if (_securityPrincipleRepository.SecurityPrincipleExists(displayName, DbContext))
                return NotFound("displayName already exists!");

            if (!ModelState.IsValid)
                return BadRequest();

            var securityPrincipleMap = _mapper.Map<SecurityPrinciple>(updatedSecurityPrinciple);

            if (!_securityPrincipleRepository.UpdateSecurityPrinciple(securityPrincipleMap, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong updating Security Principle");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //Delete

        [HttpDelete("{{Id}}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSecurityPrinciple(int Id, string DbContext)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(Id, DbContext))
            {
                return NotFound();
            }

            var securityPrincipleToDelete = _securityPrincipleRepository.GetSecurityPrincipleById(Id, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_securityPrincipleRepository.DeleteSecurityPrinciple(securityPrincipleToDelete, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();
        }

        [HttpDelete("{{displayName}}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSecurityPrincipleByDisplayName(string displayName, string DbContext)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(displayName, DbContext))
            {
                return NotFound();
            }

            var securityPrincipleToDelete = _securityPrincipleRepository.GetSecurityPrincipleByDisplayName(displayName, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_securityPrincipleRepository.DeleteSecurityPrinciple(securityPrincipleToDelete, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();
        }
    }
}
