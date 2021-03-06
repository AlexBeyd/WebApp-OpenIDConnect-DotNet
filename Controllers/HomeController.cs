using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoeLovers.Api.Managers;
using ShoeLovers.Repo.Model;
using WebApp_OpenIDConnect_DotNet.Mappers;
using WebApp_OpenIDConnect_DotNet.Models;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IShoeSizeManager _shoeSizeMgr;
        IUserSelectionManager _userMgr;

        public HomeController(ILogger<HomeController> logger, IShoeSizeManager shoeSizeMgr, IUserSelectionManager userMgr)
        {
            _logger = logger;
            _shoeSizeMgr = shoeSizeMgr;
            _userMgr = userMgr;
        }

        public async Task<IActionResult> Index()
        {
            var mapper = new ShoeSizeMapper();

            //TODO: this should come in one call to database
            var availableSizes = (await _shoeSizeMgr.ListAll()).Select(s => mapper.ToView(s));
            var userSelected = await _userMgr.ListAsync(GetLoggedUserId());
            /////////////////////////////////

            var updatedForView = new List<ShoeSizeView>();

            //mark selected sizes accordignly to user selected data
            foreach (var item in availableSizes)
            {
                if (userSelected.Any(u => u.ShoeSizeId == item.Id))
                {
                    item.IsSelected = true;
                }

                updatedForView.Add(item);
            }

            return View(updatedForView);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IEnumerable<ShoeSizeView> postedData)
        {
            var userId = GetLoggedUserId();

            //only user selected are sent to database
            await _userMgr.PersistRangeExactAsync(
                postedData.Where(v => v.IsSelected).Select(v => new UserSelectionEntity {
                    ShoeSizeId = v.Id,
                    UserId = userId
                   }
                )).ConfigureAwait(false);
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Guid GetLoggedUserId()
        {
            return new Guid(HttpContext.User.Claims.ToArray()[2].Value);
        }
    }
}
