using Forum.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Extenstions
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly IPrivateMessagesQuery _privateMessagesQuery;

        // TODO: Obter cliente logado
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");


        public NotificationViewComponent(IPrivateMessagesQuery privateMessagesQuery)
        {
            _privateMessagesQuery = privateMessagesQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var message = await _privateMessagesQuery.GetAll();
            var itens = message.ToList()?.Count ?? 0; //aqui vou retornar total de msg nao lidas

            return View(itens);
        }
    }
}
