using Forum.Application.Commands.Area;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class AreaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IAreaQuery _areaQuery;

        public AreaController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IAreaQuery areaQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _areaQuery = areaQuery;
        }

        public async Task<IActionResult> Index(int pg = 1)
        {
            var areas = await _areaQuery.GetAll();

            //limit iten for page
            const int pageSize = 5;

            if (pg < 1)
                pg = 1;

            int totalItens = areas.Count();
            var pager = new Pager(totalItens, pg, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = areas.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);
            //return View(sections);
        }

        public async Task<IActionResult> GetAll()
        {
            return View();
        }


        [HttpGet]
        [Route("add-area")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("add-area")]
        public async Task<IActionResult> Create(AreaDTO area)
        {
            if (!ModelState.IsValid) return View(area);

            var command = new CreateAreaCommand(area.Name);

            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Erros"] = GetMessageErros();


            return View(area);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            var section = await _areaQuery.GetById(id);

            var comand = new DeleteAreaCommand(id);

            await _mediatorHandler.SendCommand(comand);


            if (IsvalidOpperation())
                return RedirectToAction("Index");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Guid id, string name)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "Name can't be empty";
                return RedirectToAction("Index");
            }

            var section = await _areaQuery.GetById(id);

            if (section == null) return BadRequest("Section not found.");

            var comand = new UpdateAreaCommand(id, name);

            await _mediatorHandler.SendCommand(comand);

            if (IsvalidOpperation())
                return RedirectToAction("Index", "Section");

            //if have erros  then get from domainnotification
            TempData["Errors"] = GetMessageErros();

            return View();
        }

    }
}
