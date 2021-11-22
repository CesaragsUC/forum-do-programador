using Forum.Application.Commands;
using Forum.Application.Commands.Section;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class SectionController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISectionQuery _sectionQuery;
        private readonly IAreaQuery _areaQuery;

        public SectionController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ISectionQuery sectionQuery,
            IAreaQuery areaQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _sectionQuery = sectionQuery;
            _areaQuery = areaQuery;
        }

        public async Task<IActionResult> Get()
        {
            return View();
        }

        //public IActionResult Index() => View(); //only in NET Core 5

        [Route("sections")]
        public async Task<IActionResult> Index(int pg = 1)
        {
            var sections = await _sectionQuery.GetAll();

            //limit iten for page
            const int pageSize = 5;

            if (pg < 1)
                pg = 1;

            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string actionName = ControllerContext.ActionDescriptor.ActionName;

            int totalItens = sections.Count();
            var pager = new Pager(totalItens, pg, controllerName, actionName, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = sections.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);
            //return View(sections);
        }

        private void LoadViewBags()
        {

        }

        [HttpGet]
        [Route("add-section")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Areas = new SelectList(await _areaQuery.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("add-section")]
        public async Task<IActionResult> Create(SectionDTO section)
        {

            if (!ModelState.IsValid) return View(section);

            var command = new CreateSectionCommand(section.Name, section.IsActive, section.AreaId);

            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Erros"] = GetMessageErros();


            return View(section);
        }

        [HttpGet]
        [Route("update-section")]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["Error"] = "Id can't be empty";
                return RedirectToAction("Index");
            }

            var section = await _sectionQuery.GetById(id);

            ViewBag.Areas = new SelectList(await _areaQuery.GetAll(), "Id", "Name", section.AreaId);

            if (section == null) return BadRequest("Section not found.");

            return View(section);
        }

        [HttpPost]
        [Route("update-section")]
        public async Task<IActionResult> Update(SectionDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var comand = new UpdateSectionCommand(model.Id, model.Name,model.AreaId);

            await _mediatorHandler.SendCommand(comand);

            if (IsvalidOpperation())
                return RedirectToAction("Index", "Section");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();

        }

        [HttpDelete]
        [Route("delete-section")]
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
        [Route("inative-section")]
        public async Task<IActionResult> Inative(Guid id, bool active)
        {
            if (id == Guid.Empty)
            {
                TempData["Error"] = "Invalid Id";
                return RedirectToAction("Index");
            }

            var section = await _sectionQuery.GetById(id);

            var comand = new InativeSectionCommand(id, active);

            await _mediatorHandler.SendCommand(comand);

            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return RedirectToAction("Index");

        }

    }
}
