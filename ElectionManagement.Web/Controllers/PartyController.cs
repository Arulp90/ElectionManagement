using ElectionManagement.Models;
using ElectionManagement.Web.Helper;
using ElectionManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using Constant = ElectionManagement.Web.Helper.Constant;

namespace ElectionManagement.Web.Controllers
{
    public class PartyController : Controller
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IConfiguration _configuration;
        private readonly string serviceURL;
        public PartyController(IConfiguration configuration, IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
            _configuration = configuration;
            serviceURL = _configuration["ServiceUrl"];
        }
        public async Task<ActionResult> Index()
        {
            var partyList = await _httpHelper.GetWebapiResponse<List<Party>>($"{serviceURL}{Constant.getParty}");

            return View(partyList);
        }
    }
}
