using Forum.Application.Commands.Area;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler.Command
{
    public class AreaCommandHandler : ValidateComandBase, 
        IRequestHandler<CreateAreaCommand, bool>,
        IRequestHandler<UpdateAreaCommand, bool>,
        IRequestHandler<DeleteAreaCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAreaRepository _areaRepository;

        public AreaCommandHandler(
            IMediatorHandler mediatorHandler,
            IAreaRepository areaRepository):base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _areaRepository = areaRepository;
        }

        public async Task<bool> Handle(CreateAreaCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var area = new Area(comand.Name);

            _areaRepository.Add(area);

            return await _areaRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateAreaCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var area = await _areaRepository.GetById(comand.Id);
           
            if (area == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("area", "Area not found!"));
                return false;
            }

            area.UpdateName(comand.Name);

            _areaRepository.Update(area);

            return await _areaRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteAreaCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var area = await _areaRepository.GetById(comand.Id);
          
            if (area == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("area", "Area not found!"));
                return false;
            }
            _areaRepository.Delete(area);

            return await _areaRepository.UnitOfWork.Commit();
        }
    }
}
