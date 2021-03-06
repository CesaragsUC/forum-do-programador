using EventSourcing;
using Forum.Application.Commands;
using Forum.Application.Commands.Area;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.PrivateMessages;
using Forum.Application.Commands.Ranking;
using Forum.Application.Commands.ReportUser;
using Forum.Application.Commands.Section;
using Forum.Application.Commands.TopicViews;
using Forum.Application.Commands.User;
using Forum.Application.Commands.UserFirend;
using Forum.Application.Commands.UserInfo;
using Forum.Application.Events;
using Forum.Application.Events.UserFriend;
using Forum.Application.Handler;
using Forum.Application.Handler.Command;
using Forum.Application.Queries;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Data.EventSourcing;
using Forum.Core.Messages.CommonMessage.Notification;
using Forum.Domain.Interfaces;
using Forum.Infra;
using Forum.Infra.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.DependencyResolver
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //EventStoreDb
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourceRepository, EventSourceRepository>();

            //Forum
            services.AddScoped<ForumContext>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRankingRepository, RankingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();
            services.AddScoped<ITopicViewsRepository, TopicViewsRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUserFriendRepository, UserFriendRepository>();
            services.AddScoped<IMessageCommentRepository, MessageCommentRepository>();
            services.AddScoped<IReportUserRepository, ReportUserRepository>();


            //Queries
            services.AddScoped<ISectionQuery, SectionQuery>();
            services.AddScoped<IAreaQuery, AreaQuery>();
            services.AddScoped<ICommentQuery, CommentQuery>();
            services.AddScoped<IRankingQuery, RankingQuery>();
            services.AddScoped<ITopicQuery, TopicQuery>();
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<ITopicViewsQuery, TopicViewsQuery>();
            services.AddScoped<IPrivateMessagesQuery, PrivateMessagesQuery>();
            services.AddScoped<IUserInformationfoQuery, UserInformationfoQuery>();
            services.AddScoped<IUserFriendQuery, UserFriendQuery>();
            services.AddScoped<IMessaCommentsQuery, MessaCommentQuery>();
            services.AddScoped<IReportUserQuery, ReportUserQuery>();

            //Events
            services.AddScoped<INotificationHandler<TopicCreatedEvent>, TopicHandlerEvent>();
            services.AddScoped<INotificationHandler<SectionCreatedEvent>, SectionHandlerEvent>();
            services.AddScoped<INotificationHandler<UserFriendEvent>, UserFriendHandlerEvent>();



            //ComandHandlers
            services.AddScoped<IRequestHandler<CreateTopicCommand, bool>, TopicCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTopicCommand, bool>, TopicCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTopicCommand, bool>, TopicCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTopicCommand, bool>, TopicCommandHandler>();

            services.AddScoped<IRequestHandler<CreateSectionCommand,bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteSectionCommand, bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSectionCommand, bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<InativeSectionCommand, bool>, SectionCommandHandler>();

            services.AddScoped<IRequestHandler<CreateAreaCommand, bool>, AreaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAreaCommand, bool>, AreaCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAreaCommand, bool>, AreaCommandHandler>();

            services.AddScoped<IRequestHandler<AddComentCommand, bool>, CommentCommandHandler>();
            services.AddScoped<IRequestHandler<EditComentCommand, bool>, CommentCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteComentCommand, bool>, CommentCommandHandler>();

            services.AddScoped<IRequestHandler<AddPrivateMessagesCommand, bool>, PrivateMessagesCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateIsSeenMessagesCommand, bool>, PrivateMessagesCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePrivateMessagesCommand, bool>, PrivateMessagesCommandHandler>();
            services.AddScoped<IRequestHandler<AddMessagesCommentCommand, bool>, PrivateMessagesCommandHandler>();
            

            services.AddScoped<IRequestHandler<AddTopicViewsCommand, bool>, TopicViewsCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTopicViewsCommand, bool>, TopicViewsCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTopicViewsCommand, bool>, TopicViewsCommandHandler>();

            services.AddScoped<IRequestHandler<AddUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserAvatarCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserInformationCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<AddUserInformationCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<BanUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UnBanUserCommand, bool>, UserCommandHandler>();

            services.AddScoped<IRequestHandler<AddUserFriendCommand, bool>, UserFriendCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserFriendCommand, bool>, UserFriendCommandHandler>();

            services.AddScoped<IRequestHandler<AddReportCommand, bool>, ReportUserCommandHandler>();

            services.AddScoped<IRequestHandler<AddScoreCommand, bool>, RankingCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveScoreCommand, bool>, RankingCommandHandler>();

        }

    }
}
