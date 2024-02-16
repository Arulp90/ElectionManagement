using ElectionManagement.Models;
using ElectionManagement.Web.Helper;
using ElectionManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElectionManagement.Web.Controllers
{
    public class ConstituencyController : Controller
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IConfiguration _configuration;
        private readonly string serviceURL;
        public ConstituencyController(IConfiguration configuration, IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
            _configuration = configuration;
            serviceURL = _configuration["ServiceUrl"];
        }
        /// <summary>
        /// To Get list of Constituency
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var constituencyList = await _httpHelper.GetWebapiResponse<List<Constituency>>($"{serviceURL}{Constant.getConstituency}");

            return View(constituencyList);
        }

        /// <summary>
        /// For create page
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            var stateList = await _httpHelper.GetWebapiResponse<List<State>>($"{serviceURL}{Constant.getState}");

            ViewBag.StateList = stateList;
            return View();
        }

        /// <summary>
        /// To add new Constituency
        /// </summary>
        /// <param name="constituencyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConstituencyViewModel constituencyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stateList = await _httpHelper.GetWebapiResponse<List<State>>($"{serviceURL}{Constant.getState}");
                    ViewBag.StateList = stateList;

                    var constituency = new Constituency()
                    {
                        ConstituencyName = constituencyViewModel.ConstituencyName,
                        StateId = int.Parse(constituencyViewModel.State)
                    };
                    await _httpHelper.PostAsync($"{serviceURL}{Constant.addConstituency}", JsonConvert.SerializeObject(constituency).ToString());
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
