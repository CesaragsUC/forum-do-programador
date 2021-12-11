using Forum.Application.Commands.UserInfo;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicQuery _topicQuery;
        private readonly ISectionQuery _sectionQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly IUserQuery _userQuery;
        private readonly IToastNotification _toastNotification;
        private readonly IUserInformationfoQuery _userInformationfoQuery;
        private readonly IUserFriendQuery _userFriendQuery;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery,
            IUserQuery userQuery,
            IToastNotification toastNotification,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IUserInformationfoQuery userInformationfoQuery,
            IUserFriendQuery userFriendQuery) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
            _userQuery = userQuery;
            _signInManager = signInManager;
            _userManager = userManager;
            _toastNotification = toastNotification;
            _userInformationfoQuery = userInformationfoQuery;
            _userFriendQuery = userFriendQuery;
        }
        public async Task<IActionResult> Index(Guid loggedid, Guid profileid, string isowner)
        {


            bool isOwnerProfile = Convert.ToBoolean(Convert.ToInt32(isowner));
            var userInfo = new UserInformationDTO();

            if (!isOwnerProfile)
            {


                var loggedUser = await _userQuery.GetByIdentityId(loggedid);

                var userProfile = await _userQuery.GetByIdentityId(profileid);

                if (loggedUser == null || userProfile == null)
                {
                    _toastNotification.AddErrorToastMessage("An unexpected error occur");
                    return RedirectToAction("Index", "Home");
                }

                var user = await _userQuery.GetByIdentityId(profileid);
                if (user == null)
                    _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");

                var info = await _userInformationfoQuery.GetByUserId(user.Id);
                if (info == null)
                {
                    _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User info");
                    return RedirectToAction("Index", "Home");
                }

                userInfo.User = user;
                var friendList = await _userFriendQuery.GetByUserId(user.Id);
                userInfo.UserFriend = friendList.ToList();

                ViewBag.IsOwnerProfile = loggedUser.Id == userProfile.Id;
                TempData["LogedUserId"] = loggedid;
                return View(userInfo);
            }
            else
            {
                var user = await _userQuery.GetByIdentityId(loggedid);
                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");
                    return RedirectToAction("Index", "Home");
                }


                var info = await _userInformationfoQuery.GetByUserId(user.Id);
                if (info == null)
                {
                    userInfo.User = user;

                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = true;
                    TempData["LogedUserId"] = loggedid;
                    return View(userInfo);
                }
                else
                {
                    userInfo = info;
                    userInfo.User = user;
                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = true;
                    TempData["LogedUserId"] = loggedid;
                    return View(userInfo);
                }


            }


        }

        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "User", new { loggedid = model.Id, profileid = Guid.Empty, isowner = 1 });
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateInfo(UserInformationDTO model)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "User", new { loggedid = model.UserId, profileid = Guid.Empty, isowner = 1 });
            }

            //get by identity id
            var user = await _userQuery.GetByIdentityId(model.UserId);

            //info exist?
            var info = await _userInformationfoQuery.GetByUserId(user.Id);

            if (info != null)
            {
                var command = new UpdateUserInformationCommand(info.Id, user.Id, model.WebSite, model.GitHub,
                    model.Twitter, model.Instagran, model.FaceBook, model.FullName, model.Adress, 
                    model.Occupation, model.Email);
                await _mediatorHandler.SendCommand(command);
            }
            else
            {
                var command = new AddUserInformationCommand(user.Id, model.WebSite, model.GitHub,
                    model.Twitter, model.Instagran, model.FaceBook, model.FullName, model.Adress,
                    model.Occupation, model.Email);
                await _mediatorHandler.SendCommand(command);
            }


            if (IsvalidOpperation())
                _toastNotification.AddSuccessToastMessage("Information updateed Successfully");

            return RedirectToAction("Index", "User", new { loggedid = model.UserId, profileid = Guid.Empty, isowner = 1 });


        }

        public async Task<IActionResult> Friends(Guid userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BanUser(Guid userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WeekBan(Guid userId)
        {
            return View();
        }
    }
}
