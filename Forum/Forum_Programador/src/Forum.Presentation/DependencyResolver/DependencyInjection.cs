using Forum.Application.Commands;
using Forum.Application.Commands.Area;
using Forum.Application.Commands.Section;
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

            //Notifications
            services.AddScoped<INotificationHandler<TopicCreatedEvent>, TopicHandlerEvent>();
            services.AddScoped<INotificationHandler<SectionCreatedEvent>, SectionHandlerEvent>();

            //Queries
            services.AddScoped<ISectionQuery, SectionQuery>();
            services.AddScoped<IAreaQuery, AreaQuery>();

            //ComandHandlers
            services.AddScoped<IRequestHandler<CreateTopicCommand, bool>, TopicCommandHandler>();
            services.AddScoped<IRequestHandler<CreateSectionCommand,bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteSectionCommand, bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSectionCommand, bool>, SectionCommandHandler>();
            services.AddScoped<IRequestHandler<InativeSectionCommand, bool>, SectionCommandHandler>();

            services.AddScoped<IRequestHandler<CreateAreaCommand, bool>, AreaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAreaCommand, bool>, AreaCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAreaCommand, bool>, AreaCommandHandler>();


        }

    }
}
