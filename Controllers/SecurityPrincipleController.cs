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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SecurityPrinciple>))]
        public IActionResult GetSecurityPrinciples()
        {
            var securityPrinciples = _mapper.Map<List<SecurityPrincipleDto>>(_securityPrincipleRepository.GetSecurityPrinciples());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciples);
        }

        [HttpGet("{{id}}")]
        [ProducesResponseType(200, Type = typeof(SecurityPrinciple))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrincipleById([FromQuery] int id)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(id))
                return NotFound();

            var securityPrinciple = _mapper.Map<SecurityPrincipleDto>(_securityPrincipleRepository.GetSecurityPrincipleById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciple);
        }

        [HttpGet("{{displayName}}")]
        [ProducesResponseType(200, Type = typeof(SecurityPrinciple))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrincipleByDisplayName([FromQuery] string displayName)
        {
            var securityPrinciple = _mapper.Map<SecurityPrincipleDto>(_securityPrincipleRepository.GetSecurityPrincipleByDisplayName(displayName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciple);
        }

        [HttpGet("{{principleType}}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SecurityPrinciple>))]
        [ProducesResponseType(400)]
        public IActionResult GetSecurityPrinciplesByType([FromQuery] string principleType)
        {
            var securityPrinciples = _securityPrincipleRepository.GetSecurityPrinciplesByType(principleType);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(securityPrinciples);
        }

        //Create.

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSecurityPrinciple([FromBody] SecurityPrincipleDto securityPrincipleCreate)
        {
            if (securityPrincipleCreate == null)
                return BadRequest(ModelState);

            var securityPrinciple = _securityPrincipleRepository.GetSecurityPrinciples()
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

            if (!_securityPrincipleRepository.CreateSecurityPrinciple(securityPrincipleMap))
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
        public IActionResult UpdateSecurityPrinciple(string displayName, [FromBody] SecurityPrincipleDto updatedSecurityPrinciple)
        {
            if (updatedSecurityPrinciple == null)
                return BadRequest(ModelState);

            if (displayName != updatedSecurityPrinciple.displayName)
                return BadRequest(ModelState);

            if (_securityPrincipleRepository.SecurityPrincipleExists(displayName))
                return NotFound("displayName already exists!");

            if (!ModelState.IsValid)
                return BadRequest();

            var securityPrincipleMap = _mapper.Map<SecurityPrinciple>(updatedSecurityPrinciple);

            if (!_securityPrincipleRepository.UpdateSecurityPrinciple(securityPrincipleMap))
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
        public IActionResult DeleteSecurityPrinciple(int Id)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(Id))
            {
                return NotFound();
            }

            var securityPrincipleToDelete = _securityPrincipleRepository.GetSecurityPrincipleById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_securityPrincipleRepository.DeleteSecurityPrinciple(securityPrincipleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();
        }

        [HttpDelete("{{displayName}}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSecurityPrincipleByDisplayName(string displayName)
        {
            if (!_securityPrincipleRepository.SecurityPrincipleExists(displayName))
            {
                return NotFound();
            }

            var securityPrincipleToDelete = _securityPrincipleRepository.GetSecurityPrincipleByDisplayName(displayName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_securityPrincipleRepository.DeleteSecurityPrinciple(securityPrincipleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();
        }
    }
}
