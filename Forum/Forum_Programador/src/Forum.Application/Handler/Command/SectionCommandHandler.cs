using Forum.Application.Commands;
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
        IRequestHandler<CreateSectionCommand, bool>
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISectionRepository _sectionRepository;

        public SectionCommandHandler(IMediatorHandler mediatorHandler,
            ITopicRepository topicRepository,
            ISectionRepository sectionRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _sectionRepository = sectionRepository;


        }

        public async Task<bool> Handle(CreateSectionCommand comand, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(comand)) return false;

            var section = new Section(comand.Name,comand.IsActive);

            _sectionRepository.Add(section);

            section.AddEvent(new SectionCreatedEvent(section.Id, section.Name,section.IsActive));

            return await _sectionRepository.UnitOfWork.Commit();

        }



    }
}
