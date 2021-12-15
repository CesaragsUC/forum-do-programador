using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        private readonly IMediatorHandler _mediatorHandler;

        //main user test purpose
        protected Guid UserId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        //only for test purpose
        protected Guid GetRandomUser()
        {
            Guid[] UserId = new Guid[5];
            UserId[0] = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
            UserId[1] = Guid.Parse("ab29b8d5-43b9-464b-89ef-5103461b17ea");
            UserId[2] = Guid.Parse("b9121608-2a90-4176-a92c-e13905163618");
            UserId[3] = Guid.Parse("e502e59a-a6f2-431b-9e0d-5b3a571be5c5");
            UserId[4] = Guid.Parse("6f70b259-916f-48fe-aa8f-c9a5e6be9bed");

            Random randUser = new Random();
            int index = randUser.Next(0,4);
            Guid result = UserId[index];
            return result;
        }

        public ControllerBase(
            INotificationHandler<DomainNotification> notification,
            IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notification;
            _mediatorHandler = mediatorHandler;
        }

        protected bool IsvalidOpperation()
        {
            return !_notifications.HasNotificcation();
        }

        protected IEnumerable<string> GetMessageErros()
        {
            return _notifications.GetNotification().Select(x => x.Value).ToList();
        }

        protected void NotifyError(string cod, string msg)
        {
            _mediatorHandler.PublishDomainNotification(new DomainNotification(cod, msg));
        }

        protected async Task<bool> UploadFile(IFormFile file, string imgPrefix)
        {
            if (file.Length < 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefix + file.FileName);

            if(System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Already exist a file with this name.");
                return false;
            }

            using (var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }
    }

}
