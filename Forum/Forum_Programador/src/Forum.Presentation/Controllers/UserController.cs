using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicQuery _topicQuery;
        private readonly ISectionQuery _sectionQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly IUserQuery _userQuery;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery,
            IUserQuery userQuery,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
            _userQuery = userQuery;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(Guid userId)
        {
            return View();
        }
        public async Task<IActionResult> Friends(Guid userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BanUser(Guid userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WeekBan(Guid userId)
        {
            return View();
        }
    }
}
