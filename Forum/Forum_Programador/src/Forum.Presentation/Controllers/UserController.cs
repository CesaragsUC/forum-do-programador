using Forum.Application.Commands.UserFirend;
using Forum.Application.Commands.UserInfo;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private IHttpContextAccessor _httpContextAccessor;

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
            IUserFriendQuery userFriendQuery,
            IHttpContextAccessor httpContextAccessor) : base(notifications, mediatorHandler)
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
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index(Guid loggedid, Guid profileid, string isowner)
        {

            bool isOwnerProfile = Convert.ToBoolean(Convert.ToInt32(isowner));
            var userInfo = new UserInformationDTO();

            if (!isOwnerProfile)
            {

                //get my current user by USER ID
                var loggedUser = await _userQuery.GetByIdentityId(loggedid);

                //get the profile that im visiting  by user ID
                var userProfile = await _userQuery.GetById(profileid);

                if (loggedUser == null || userProfile == null)
                {
                    _toastNotification.AddErrorToastMessage("An unexpected error occur");
                    return RedirectToAction("Index", "Home");
                }

                var user = await _userQuery.GetById(profileid);
                if (user == null)
                    _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");

                var info = await _userInformationfoQuery.GetByUserId(user.Id);
                if (info == null)
                {
                    userInfo.User = user;

                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = false;
                    TempData["LoggedUserId"] = loggedid;
                    TempData["ProfileId"] = user.Id;
                    return View(userInfo);
                }
                else
                {
                    userInfo = info;
                    userInfo.User = user;

                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = false;
                    TempData["LoggedUserId"] = loggedid;
                    TempData["ProfileId"] = user.Id;
                    return View(userInfo);
                }

            }
            else
            {
                var loggedUserName = User.Identity.Name;
                var loggedUser = await _userManager.FindByNameAsync(loggedUserName);

                //current logged user
                var user = await _userQuery.GetByIdentityId(Guid.Parse(loggedUser.Id));

                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");
                    return RedirectToAction("Index", "Home");
                }
                var updateAvatarModel = new UpdateUserAvatarDTO
                {
                    Id = user.Id,
                    IdentityId = user.IdentityId
                };

                var updatePasswordModel = new UpdateUserPasswordDTO
                {
                    Id = user.Id,
                    IdentityId = user.IdentityId
                };

                var info = await _userInformationfoQuery.GetByUserId(user.Id);
                if (info == null)
                {
                    userInfo.User = user;
                    userInfo.UpdateUserAvatar = updateAvatarModel;
                    userInfo.UpdateUserPassword = updatePasswordModel;

                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = true;
                    TempData["LoggedUserId"] = loggedid;
                    return View(userInfo);
                }
                else
                {
                    userInfo = info;
                    userInfo.User = user;
                    userInfo.UpdateUserAvatar = updateAvatarModel;
                    userInfo.UpdateUserPassword = updatePasswordModel;

                    var friendList = await _userFriendQuery.GetByUserId(user.Id);
                    userInfo.UserFriend = friendList.ToList();

                    ViewBag.IsOwnerProfile = true;
                    TempData["LoggedUserId"] = loggedid;
                    return View(userInfo);
                }


            }


        }

        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            var user = await _userQuery.GetById(userId);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> UpdateAvatar(Guid id)
        {
            var user = await _userQuery.GetByIdentityId(id);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");
                return RedirectToAction("Index", "Home");
            }

            var updateAvatarModel = new UpdateUserAvatarDTO
            {
                Id = user.Id,
                IdentityId = user.IdentityId
            };
            return View("_UpdateAvatar", updateAvatarModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvatar(UpdateUserAvatarDTO model)
        {
            if(model.AvatarUpload == null)
            {
                _toastNotification.AddErrorToastMessage("Invalid file.");
                return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
            }

            var imgprefix = Guid.NewGuid() + "_";
            if (!await UploadFile(model.AvatarUpload, imgprefix))
                return View(model);

            model.Avatar = imgprefix + model.AvatarUpload.FileName;

            var command = new UpdateUserAvatarCommand(model.Id, model.Avatar);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
                _toastNotification.AddSuccessToastMessage("updateed Successfully");

            return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateInfo(UserInformationDTO model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        _toastNotification.AddErrorToastMessage(error.ErrorMessage);  
                    }
                }

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

                if (!string.IsNullOrEmpty(model.Email) && command.IsValid())
                {
                    IdentityUser identityUser = null;
                    identityUser = await _userManager.FindByEmailAsync(user.Email);
                    if (identityUser != null)
                    {
                        if (identityUser.Email != model.Email)
                        {
                            identityUser.Email = model.Email;
                            var resultUpdate = await _userManager.UpdateAsync(identityUser); //first we update the email
                            if (!resultUpdate.Succeeded)//if  get unsuccessful, we need to abort all, then return a error
                            {
                                _toastNotification.AddErrorToastMessage("An unexpected error occurred while update email");
                                return RedirectToAction("Index", "User", new { loggedid = model.UserId, profileid = Guid.Empty, isowner = 1 });
                            }
                                
                        }
                    }
                }
            }
            else
            {
                var command = new AddUserInformationCommand(user.Id, model.WebSite, model.GitHub,
                    model.Twitter, model.Instagran, model.FaceBook, model.FullName, model.Adress,
                    model.Occupation, model.Email);

                await _mediatorHandler.SendCommand(command);

                if (!string.IsNullOrEmpty(model.Email) && command.IsValid())
                {
                    IdentityUser identityUser = null;
                    identityUser = await _userManager.FindByEmailAsync(model.Email);
                    if (identityUser != null)
                    {
                        if (identityUser.Email != model.Email)
                        {
                            identityUser.Email = model.Email;
                            var resultUpdate = await _userManager.UpdateAsync(identityUser); //first we update the email
                            if (!resultUpdate.Succeeded)//if  get unsuccessful, we need to abort all, then return a error
                            {
                                _toastNotification.AddErrorToastMessage("An unexpected error occurred while update email");
                                return RedirectToAction("Index", "User", new { loggedid = model.UserId, profileid = Guid.Empty, isowner = 1 });
                            }
                        }
                    }
                }
            }


            if (IsvalidOpperation())
                _toastNotification.AddSuccessToastMessage("Information updateed Successfully");

            return RedirectToAction("Index", "User", new { loggedid = model.UserId, profileid = Guid.Empty, isowner = 1 });


        }

      
        public async Task<IActionResult> Friends(Guid userid)
        {

            var loggedUserName = User.Identity.Name;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserName);

            //current logged user
            var currentuser = await _userQuery.GetByIdentityId(Guid.Parse(loggedUser.Id));

            var userToFollow = await _userQuery.GetById(userid);

            var command = new AddUserFriendCommand(currentuser.Id, userToFollow.Id);
            await _mediatorHandler.SendCommand(command);

            if(IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("You are Foloowing " + userToFollow.Name);
                return RedirectToAction("Index", "User", new { loggedid = currentuser.IdentityId, profileid = userToFollow.IdentityId, isowner = 0 });
            }
            else
            {
                foreach (var error in GetMessageErros())
                {
                    _toastNotification.AddErrorToastMessage("Error: " + error);
                }
                
                return RedirectToAction("Index", "User", new { loggedid = currentuser.IdentityId, profileid = userToFollow.Id, isowner = 0 });
            }

            _toastNotification.AddSuccessToastMessage("A error accoured to follow " + userToFollow.Name);
            return RedirectToAction("Index", "User", new { loggedid = currentuser.IdentityId, profileid = userToFollow.Id, isowner = 0 });
        }


        [HttpPost]
        public async Task<IActionResult> Reportuser(Guid userId)
        {
            return View();
        }


        public async Task<IActionResult> UpdatePassword(Guid userId)
        {
            var user = await _userQuery.GetById(userId);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        _toastNotification.AddErrorToastMessage(error.ErrorMessage);
                    }
                }
                return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
            }

            var userData = await _userQuery.GetById(model.Id);
            if (userData == null)
            {
                _toastNotification.AddErrorToastMessage("User not found");
                return View(model);
            }

            IdentityUser user = null;
            user = await _userManager.FindByEmailAsync(userData.Email);
            
            if (user != null)
            {

                try
                {

                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.OldPassword, false, true);

                    if (!result.Succeeded)
                    {
                        _toastNotification.AddErrorToastMessage("Somethings went a wrong , the old password is incorrect.");
                        return View(model); 

                    }


                    var token = await _userManager
                        .GeneratePasswordResetTokenAsync(user); //generate a token to allow change password

                    var resultResetPass =
                        await _userManager.ResetPasswordAsync(user, token, model.Password); //then change password

                    //if  get unsuccessful, we need to abort all, then return a error
                    if (!resultResetPass.Succeeded) 
                    {
                        _toastNotification.AddErrorToastMessage("Somethings went a wrong while try update password profile.");
                        return View(model);
                    }

                }
                catch (Exception ex)
                {
                    _toastNotification.AddErrorToastMessage("An Error occour");
                    return View();

                }
            }
            _toastNotification.AddSuccessToastMessage(" password updated successfully.");
            return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmail(UpdateUserEmailDTO model)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error occur");
                return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
            }

            var userData = await _userQuery.GetByIdentityId(model.Id);
            if (userData == null)
            {
                _toastNotification.AddErrorToastMessage("User not found");
                return View(model);
            }

            IdentityUser user = null;
            user = await _userManager.FindByEmailAsync(userData.Email);

            if (user != null)
            {

                try
                {

                    if (user.Email != model.Email)
                    {
                        user.Email = model.Email;
                        var resultUpdate = await _userManager.UpdateAsync(user); //first we update the email
                        if (!resultUpdate.Succeeded)//if  get unsuccessful, we need to abort all, then return a error
                        {
                            _toastNotification.AddErrorToastMessage("Somethings went a wrong while try update email profile.");
                            return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });
                        }
                    }

                    //criar um UpdateEmailCommand

                }
                catch (Exception ex)
                {
                    _toastNotification.AddErrorToastMessage("An Error occour");
                    return RedirectToAction("Index", "User", new { loggedid = model.IdentityId, profileid = Guid.Empty, isowner = 1 });

                }
            }

            return View();
        }
    }
}
