using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserQuery _userQuery;
        private readonly IAreaQuery _areaQuery;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IAreaQuery areaQuery,
            IUserQuery userQuery,
            ILogger<HomeController> logger,
             SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _areaQuery = areaQuery;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _userQuery = userQuery;
        }

        public async Task<IActionResult> Index()
        {
            var loogedUser = HttpContext.User;
            var user = await _userManager.GetUserAsync(loogedUser);
            
            if(user != null)
            {
                TempData["UserId"] = user.Id;

                var userData = await _userQuery.GetByIdentityId(Guid.Parse(user.Id));
                ViewBag.UserData = userData;
            }


            var areas = await _areaQuery.GetAll();

            return View(areas);
        }

        public async  Task<IActionResult>DrawMenu()
        {
            var loogedUser = HttpContext.User;
            var user = await _userManager.GetUserAsync(loogedUser);

            var userData = await _userQuery.GetByIdentityId(Guid.Parse(user.Id));

            return PartialView("_Headermenu", userData);
        }


        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "An error has occurred! Please try again later or contact our support.";
                modelErro.Titulo = "An error has occurred!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "The page you are looking for does not exist! <br />If you have any questions, please contact our support.";
                modelErro.Titulo = "Ops! Page not found.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Your profile not have permission to do that..";
                modelErro.Titulo = "Access Denied";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
