using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediatorHandler _mediatorHandler;

        private readonly IAreaQuery _areaQuery;

        public HomeController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IAreaQuery areaQuery,
            ILogger<HomeController> logger) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _areaQuery = areaQuery;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var areas = await _areaQuery.GetAll();

            return View(areas);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
