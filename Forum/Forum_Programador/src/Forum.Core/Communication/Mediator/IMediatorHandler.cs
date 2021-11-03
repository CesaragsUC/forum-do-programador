using Forum.Core.Messages;
using Forum.Core.Messages.CommonMessage.DomainEvents;
using Forum.Core.Messages.CommonMessage.Notification;
using System.Threading.Tasks;

namespace Forum.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T _event) where T : Event;

        Task<bool> SendCommand<T>(T command) where T : Command;

        Task PublishDomainNotification<T>(T notification) where T : DomainNotification;

        Task PublishDomainEvent<T>(T notification) where T : DomainEvents;

    }
}
