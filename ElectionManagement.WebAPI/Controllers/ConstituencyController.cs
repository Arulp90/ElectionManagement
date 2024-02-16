using ElectionManagement.Models;
using ElectionManagement.WebAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ElectionManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstituencyController : ControllerBase
    {
        private readonly IConstituencyRepository _constituencyRepo;

        public ConstituencyController(IConstituencyRepository constituencyRepo)
        {
            _constituencyRepo = constituencyRepo;
        }

        [HttpGet]
        [Route("GetConstituency")]
        public async Task<ActionResult<IEnumerable<Constituency>>> Get()
        {
            var constituencyList = await _constituencyRepo.GetAll();
            return Ok(constituencyList);
        }

        [HttpGet]
        [Route("Getstates")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var stateList = await _constituencyRepo.GetStates();
            return Ok(stateList);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async void Post([FromBody] Constituency constituency)
        {
            await _constituencyRepo.InsertRecord(constituency);

        }
    }
}
