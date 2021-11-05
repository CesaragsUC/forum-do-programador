using Forum.Application.Commands;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class SectionController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISectionQuery _sectionQuery;

        public SectionController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ISectionQuery sectionQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _sectionQuery = sectionQuery;
        }

        public async Task<IActionResult> Get()
        {
            return View();
        }

        //public IActionResult Index() => View(); //only in NET Core 5

        [Route("sections")]
        public async Task<IActionResult> Index()
        {
            var sections = await _sectionQuery.GetAll(); 
            return View(sections);
        }


        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create(SectionDTO section)
        {

            if (!ModelState.IsValid) return View(section);

            var command = new CreateSectionCommand(section.Name,section.IsActive);
            
            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
                return RedirectToAction("Index");


            return View(section);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(Guid id)
        {

            return View();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }

    }
}
