using Forum.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Forum.Presentation.Extenstions
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly IPrivateMessagesQuery _privateMessagesQuery;
        private readonly IMessaCommentsQuery _messaCommentsQuery;
        private readonly IUserQuery _userQuery;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public NotificationViewComponent(IPrivateMessagesQuery privateMessagesQuery,
            IMessaCommentsQuery messaCommentsQuery,
            SignInManager<IdentityUser> signInManager,
                UserManager<IdentityUser> userManager,
            IUserQuery userQuery)
        {
            _privateMessagesQuery = privateMessagesQuery;
            _messaCommentsQuery = messaCommentsQuery;
            _signInManager = signInManager;
            _userManager = userManager;
            _userQuery = userQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var loggedUserName = User.Identity.Name;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserName);

            //current logged user
            var user = await _userQuery.GetByIdentityId(Guid.Parse(loggedUser.Id));

            var result =  _messaCommentsQuery.GetMessagesAndRepliesNotReaded(user.Id);

            return View(result);
        }
    }
}
