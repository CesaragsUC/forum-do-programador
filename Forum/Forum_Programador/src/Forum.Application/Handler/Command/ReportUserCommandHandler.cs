using Forum.Application.Commands.ReportUser;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Entities;

namespace Forum.Application.Handler.Command
{
    public class ReportUserCommandHandler : ValidateComandBase,
        IRequestHandler<AddReportCommand,bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IReportUserRepository _reportUserRepository;


        public ReportUserCommandHandler(IMediatorHandler mediatorHandler, 
            IReportUserRepository reportUserRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _reportUserRepository = reportUserRepository;
        }

        public async Task<bool> Handle(AddReportCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var report = new ReportUsers(command.UserSendReportId, command.UserId, command.Reason);

            _reportUserRepository.Add(report);

            return await _reportUserRepository.UnitOfWork.Commit();
        }
    }
}
