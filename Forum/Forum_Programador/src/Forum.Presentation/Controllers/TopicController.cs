using Forum.Application.Commands;
using Forum.Application.Commands.Comments;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        public TopicController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
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


            var comments = await _commentQuery.GetByTopicId(topic.Id,GetRandomUser());
            ViewBag.SectionId = topic.SectionId;

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
            if (sectionId == Guid.Empty || string.IsNullOrEmpty(htmlcode) || string.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("Error","Invalid form data");
                return View();
            }

            ViewData["IsPosted"] = true;
            ViewData["PostedValue"] = htmlcode;


            var command = new CreateTopicCommand(title, htmlcode, GetRandomUser(), sectionId);
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

            var command = new AddComentCommand(topicId, GetRandomUser(), htmlcode);
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
    }
}
