using Forum.Application.Commands;
using Forum.Application.Commands.Section;
using Forum.Application.Events;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Handler
{
    public class SectionCommandHandler : ValidateComandBase,
        IRequestHandler<CreateSectionCommand, bool>,
          IRequestHandler<DeleteSectionCommand, bool>,
          IRequestHandler<UpdateSectionCommand, bool>,
        IRequestHandler<InativeSectionCommand, bool>
        

    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISectionRepository _sectionRepository;

        public SectionCommandHandler(
            IMediatorHandler mediatorHandler,
            ISectionRepository sectionRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _sectionRepository = sectionRepository;


        }

        public async Task<bool> Handle(CreateSectionCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var section = new Section(comand.Name,comand.IsActive, comand.AreaId);

            _sectionRepository.Add(section);

            //send a event
            section.AddEvent(new SectionCreatedEvent(section.Id, section.Name,section.IsActive));

            return await _sectionRepository.UnitOfWork.Commit();

        }

        public async Task<bool> Handle(DeleteSectionCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var section = await _sectionRepository.GetById(comand.Id);


            if (section == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("section", "Section not found."));
                return false;
            }


            _sectionRepository.Delete(section);

            return await _sectionRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateSectionCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var section = await _sectionRepository.GetById(comand.Id);


            if (section == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("section", "Section not found."));
                return false;
            }

            //fazer mapeamento de sectionDTO pra section

            section.UpdateSectionName(comand.Name);

            _sectionRepository.Update(section);

            return await _sectionRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(InativeSectionCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var section = await _sectionRepository.GetById(comand.Id);

            if (section == null)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("section","Section not found."));
                return false;
            }

            //fazer mapeamento de sectionDTO pra section

            section.InativeSection(comand.IsActive);

            _sectionRepository.Update(section);

            return await _sectionRepository.UnitOfWork.Commit();
        }
    }
}
