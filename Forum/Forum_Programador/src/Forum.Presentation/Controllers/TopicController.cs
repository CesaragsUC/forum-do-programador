using Forum.Application.Commands;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.Ranking;
using Forum.Application.Commands.TopicViews;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class TopicController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicQuery _topicQuery;
        private readonly ISectionQuery _sectionQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserQuery _userQuery;
        private readonly IToastNotification _toastNotification;

        public TopicController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery,
             UserManager<IdentityUser> userManager,
              IToastNotification toastNotification,
              IUserQuery userQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
            _userManager = userManager;
            _toastNotification = toastNotification;
            _userQuery = userQuery;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var section = await _sectionQuery.GetById(id);
            ViewBag.SectionName = section.Name;

            var topics = await _topicQuery.GetBySectionId(section.Id);

            //When click in create topic, we need to pass sectionID to save in topic -> sectionId
            ViewBag.SectionId = id;

            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> ViewTopic(Guid id)
        {
            var topic = await _topicQuery.GetById(id);
            ViewBag.TopicTitle = topic.Title;
            ViewBag.TopicId = topic.Id;

            var loogedUser = HttpContext.User;
            var userIdentity = await _userManager.GetUserAsync(loogedUser);

            if (userIdentity == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "Home");
            }

            var user = await _userQuery.GetByIdentityId(Guid.Parse(userIdentity.Id));

            var comments = await _commentQuery.GetByTopicId(topic.Id, user.Id);
            ViewBag.SectionId = topic.SectionId;

            //add +1 view to thread if user its seen first time
            var command = new AddTopicViewsCommand(id, user.Id);
            await _mediatorHandler.SendCommand(command);

            TempData["LoggedUserId"] = userIdentity.Id;

            return View(comments);
        }

        [HttpGet]
        public IActionResult CreateTopic(Guid id)
        {
            //Need sectionID to save in topic-> sectionId
            ViewBag.SectionId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(string htmlcode, string title, Guid sectionId)
        {
            var loogedUser = HttpContext.User;
            var userIdentity = await _userManager.GetUserAsync(loogedUser);

            if (userIdentity == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "Home");
            }

            var user = await _userQuery.GetByIdentityId(Guid.Parse(userIdentity.Id));

            if (sectionId == Guid.Empty || string.IsNullOrEmpty(htmlcode) || string.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("Error","Invalid form data");
                return View();
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;


            var command = new CreateTopicCommand(title, htmlcode, user.Id, sectionId);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
                return RedirectToAction("Index", "Topic", new { id = sectionId });

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Reply(string htmlcode, Guid sectionId, Guid topicId)
        {
            if (sectionId == Guid.Empty || string.IsNullOrEmpty(htmlcode) || topicId == Guid.Empty)
            {
                ModelState.AddModelError("Error", "Invalid form data");
                return View();
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;


            var loogedUser = HttpContext.User;
            var userIdentity = await _userManager.GetUserAsync(loogedUser);

            if (userIdentity == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "Home");
            }

            var user = await _userQuery.GetByIdentityId(Guid.Parse(userIdentity.Id));

            var command = new AddComentCommand(topicId, user.Id, htmlcode);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
                return RedirectToAction("Index", "Topic", new { id = sectionId });

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditComment(Guid id)
        {
            ViewData["EditComment"] = true;

            var comment = await _commentQuery.GetById(id);

            ViewData["HtmlComment"] = comment.Text;
            ViewData["CommentId"] = comment.Id;
            ViewData["TopicId"] = comment.TopicId;

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(Guid commentid,Guid topicid, string htmlcode)
        {
            var comment = await _commentQuery.GetById(commentid);

            if (commentid == Guid.Empty || topicid == Guid.Empty || string.IsNullOrEmpty(htmlcode))
            {
                ViewData["HtmlComment"] = comment.Text;
                ViewData["CommentId"] = comment.Id;
                ViewData["TopicId"] = comment.TopicId;

                ModelState.AddModelError("Error", "Invalid form data");

                return View(comment);
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;

            var command = new EditComentCommand(commentid, topicid, htmlcode);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
                return RedirectToAction("ViewTopic", "Topic", new { id = topicid });

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LikeComment(Guid commentid)
        {

            if (commentid == Guid.Empty) return BadRequest();

            var loggedUserName = User.Identity.Name;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserName);

            //current logged user
            var user = await _userQuery.GetByIdentityId(Guid.Parse(loggedUser.Id));

            var comment = await _commentQuery.GetById(commentid);

            var command = new AddScoreCommand(comment.UserId, user.Id, comment.TopicId, comment.Id);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
            {
                return RedirectToAction("ViewTopic", "Topic", new { id = comment.TopicId });
            }
            else
            {
                foreach (var error in GetMessageErros())
                {
                    _toastNotification.AddErrorToastMessage(error);
                }
                return RedirectToAction("ViewTopic", "Topic", new { id = comment.TopicId });
            }
              

            return View();
        }
    }
}
