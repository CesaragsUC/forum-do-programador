using Forum.Application.Commands;
using Forum.Application.Events;
using Forum.Application.Handler;
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

            services.AddScoped<INotificationHandler<TopicCreatedEvent>, TopicHandlerEvent>();
            services.AddScoped<IRequestHandler<CreateTopicCommand, bool>, CreateTopicCommandHandler>();


        }

    }
}
