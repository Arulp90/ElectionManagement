using ElectionManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectionManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyRepository _partyRepo;

        public PartyController(IPartyRepository partyRepo)
        {
            _partyRepo = partyRepo;
        }
        [HttpGet]
        [Route("GetParty")]
        public async Task<ActionResult<IEnumerable<Party>>> Get()
        {
            var partyList = await _partyRepo.GetAll();
            return Ok(partyList);
        }
    }
}
