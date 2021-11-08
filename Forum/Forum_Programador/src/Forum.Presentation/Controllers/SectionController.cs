using Forum.Application.Commands;
using Forum.Application.Commands.Section;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public async Task<IActionResult> Index(int pg=1)
        {
            var sections = await _sectionQuery.GetAll();
            
            //limit iten for page
            const int pageSize = 5;

            if (pg < 1)
                pg = 1;

            int totalItens = sections.Count();
            var pager = new Pager(totalItens, pg, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = sections.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);
            //return View(sections);
        }


        [HttpGet]
        [Route("add-section")]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [Route("add-section")]
        public async Task<IActionResult> Create(SectionDTO section)
        {

            if (!ModelState.IsValid) return View(section);

            var command = new CreateSectionCommand(section.Name, section.IsActive);

            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Erros"] = GetMessageErros();


            return View(section);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(Guid id, string name)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "Name can't be empty";
                return RedirectToAction("Index");
            }

            var section = await _sectionQuery.GetById(id);

            if (section == null) return BadRequest("Section not found.");

            var comand = new UpdateSectionCommand(id, name);

            await _mediatorHandler.SendCommand(comand);
            
            if(IsvalidOpperation())
                return RedirectToAction("Index","Section");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            var section = await _sectionQuery.GetById(id);

            var comand = new DeleteSectionCommand(id);

            await _mediatorHandler.SendCommand(comand);


            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return RedirectToAction("Index");

        }

        [HttpPut]
        [Route("inative")]
        public async Task<IActionResult> Inative(Guid id,bool active)
        {
            if (id == Guid.Empty)
            {
                TempData["Error"] = "Invalid Id";
                return RedirectToAction("Index");
            }

            var section = await _sectionQuery.GetById(id);

            var comand = new InativeSectionCommand(id,active);

            await _mediatorHandler.SendCommand(comand);

            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return RedirectToAction("Index");

        }

    }
}
