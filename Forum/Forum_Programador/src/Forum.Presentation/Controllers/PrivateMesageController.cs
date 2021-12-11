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
    public class PrivateMesageController : ControllerBase
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicQuery _topicQuery;
        private readonly ISectionQuery _sectionQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly IUserQuery _userQuery;
        private readonly IPrivateMessagesQuery _privateMessagesQuery;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PrivateMesageController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery,
            IUserQuery userQuery,
            IPrivateMessagesQuery privateMessagesQuery,
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
            _privateMessagesQuery = privateMessagesQuery;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Messages(Guid userId)
        {
            if (userId == Guid.Empty) return RedirectToAction("Index", "Home");

            var messages = await _privateMessagesQuery.GetByRecipientId(userId);

            return View();
        }
    }
}
