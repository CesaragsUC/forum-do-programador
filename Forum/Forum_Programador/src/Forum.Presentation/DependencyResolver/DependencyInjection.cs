using Forum.Application.Commands;
using Forum.Application.Commands.Area;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.PrivateMessages;
using Forum.Application.Commands.Section;
using Forum.Application.Commands.TopicViews;
using Forum.Application.Commands.UserFirend;
using Forum.Application.Commands.UserInfo;
using Forum.Application.Events;
using Forum.Application.Handler;
using Forum.Application.Handler.Command;
using Forum.Application.Queries;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
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

            //Events
            services.AddScoped<INotificationHandler<TopicCreatedEvent>, TopicHandlerEvent>();
            services.AddScoped<INotificationHandler<SectionCreatedEvent>, SectionHandlerEvent>();

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
            services.AddScoped<IRequestHandler<UpdatePrivateMessagesCommand, bool>, PrivateMessagesCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePrivateMessagesCommand, bool>, PrivateMessagesCommandHandler>();


            services.AddScoped<IRequestHandler<AddTopicViewsCommand, bool>, TopicViewsCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTopicViewsCommand, bool>, TopicViewsCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTopicViewsCommand, bool>, TopicViewsCommandHandler>();

            services.AddScoped<IRequestHandler<AddUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserInformationCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<AddUserInformationCommand, bool>, UserCommandHandler>();
            


        }

    }
}
