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
using Forum.Application.Commands.PrivateMessages;
using Forum.Application.DTO;
using NToastNotify;

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
        private readonly IMessaCommentsQuery _messaCommentsQuery;
        private readonly IToastNotification _toastNotification;
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
            UserManager<IdentityUser> userManager,
            IToastNotification toastNotification, IMessaCommentsQuery messaCommentsQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
            _userQuery = userQuery;
            _signInManager = signInManager;
            _userManager = userManager;
            _toastNotification = toastNotification;
            _messaCommentsQuery = messaCommentsQuery;
            _privateMessagesQuery = privateMessagesQuery;
        }

        /// <summary>
        /// userid = logged user id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>

        public async Task<IActionResult> Index(Guid userid)
        {
            if (userid == Guid.Empty)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "Home");

            }
            var user = await _userQuery.GetByIdentityId(userid);
            TempData["LoggedUserId"] = userid;

            var messages = await _privateMessagesQuery.GetByRecipientId(user.Id);

            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> ViewMessages(Guid messageid)
        {

            if (messageid == Guid.Empty)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "Home");

            }

            //get logged user identity
            var loggedUserName = User.Identity.Name;
            var identityUser = await _userManager.FindByNameAsync(loggedUserName);

            var user = await _userQuery.GetByIdentityId(Guid.Parse(identityUser.Id));
            TempData["LoggedUserId"] = user.IdentityId;
            TempData["MessageId"] = messageid;

            var messages = await _messaCommentsQuery.GetByMessageId(messageid);
            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> Send(Guid loggedid,Guid recipientid)
        {

            if (recipientid == Guid.Empty)
            {
                _toastNotification.AddErrorToastMessage("invalid ricipient");
                return RedirectToAction("Index", "Home");

            }
            TempData["LoggedUserId"] = loggedid;

            var user = await _userQuery.GetById(recipientid);

            var messageDTO = new PrivateMessagesDTO
            {
                Recipient = user
            };

            return View(messageDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Send(string htmlcode, string title, Guid recipientid, Guid loggedid)
        {
            if (loggedid == Guid.Empty || recipientid == Guid.Empty || string.IsNullOrEmpty(htmlcode) || string.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("Error", "Invalid form data");
                return View();
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;

            var user = await _userQuery.GetByIdentityId(loggedid);

            var command = new AddPrivateMessagesCommand(user.Id, recipientid, title, htmlcode);
            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("Message sent successfully.");
                return RedirectToAction("Index", new { userid = loggedid });
            }
               

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return  View();
            //return RedirectToAction("Send", "PrivateMesage", new { loggedid = loggedid , recipientid = recipientid });
        }

        [HttpPost]
        public async Task<IActionResult> ReplyMessage(string htmlcode,  Guid loggedid, Guid messageid)
        {
            if (messageid == Guid.Empty || loggedid == Guid.Empty || string.IsNullOrEmpty(htmlcode) )
            {
                ModelState.AddModelError("Error", "Invalid form data");
                return RedirectToAction("Index", new { userid = loggedid });
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;

            var user = await _userQuery.GetByIdentityId(loggedid);

            var command = new AddMessagesCommentCommand(user.Id, messageid, htmlcode);
            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("Message sent successfully.");
                return RedirectToAction("Index", new { userid = loggedid });
            }


            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return RedirectToAction("ViewMessages", new { messageid = messageid });

        }

    }
}
