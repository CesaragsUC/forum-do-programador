using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Application.Commands.Ranking;
using Forum.Application.Extensions;
using Forum.Core.Communication.Mediator;
using Forum.Domain.Entities;
using Forum.Domain.Interfaces;
using MediatR;

namespace Forum.Application.Handler.Command
{
    public class RankingCommandHandler : ValidateComandBase,
        IRequestHandler<AddScoreCommand,bool>,
        IRequestHandler<RemoveScoreCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IRankingRepository _rankingRepository;


        public RankingCommandHandler(IMediatorHandler mediatorHandler, IRankingRepository rankingRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _rankingRepository = rankingRepository;
        }

        public async Task<bool> Handle(AddScoreCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var ranking = new Ranking(command.UserId, command.UserSentId, command.TopicId, command.CommentId);

            ranking.AddPoint();
            _rankingRepository.Add(ranking);

            return await _rankingRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(RemoveScoreCommand command, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(command)) return false;

            var ranking = await _rankingRepository.GetByCommentAndUserId(command.UserId, command.CommentId);

            ranking.RemovePoint();
            _rankingRepository.Update(ranking);

            return await _rankingRepository.UnitOfWork.Commit();
        }
    }
}
