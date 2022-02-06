using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Application.Commands;
using Forum.Application.Commands.ReportUser;
using Forum.Application.Commands.User;
using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;
using Forum.Presentation.Configuration;

namespace Forum.Presentation.Controllers
{

    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserQuery _userQuery;
        private readonly IToastNotification _toastNotification;
        private readonly IUserInformationfoQuery _userInformationfoQuery;
        private readonly IUserFriendQuery _userFriendQuery;
        private readonly ITopicQuery _topicQuery;
        private readonly IMessaCommentsQuery _commentRepository;
        private readonly IReportUserQuery _reportUserQuery;
        private readonly IRankingQuery _rankingQuery;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IUserQuery userQuery, 
            IToastNotification toastNotification, 
            IUserInformationfoQuery userInformationfoQuery, 
            IUserFriendQuery userFriendQuery,
            ITopicQuery topicQuery,
            IMessaCommentsQuery commentRepository,
            IReportUserQuery reportUserQuery,
            IRankingQuery rankingQuery,
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userQuery = userQuery;
            _toastNotification = toastNotification;
            _userInformationfoQuery = userInformationfoQuery;
            _userFriendQuery = userFriendQuery;
            _topicQuery = topicQuery;
            _commentRepository = commentRepository;
            _reportUserQuery = reportUserQuery;
            _rankingQuery = rankingQuery;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [ClaimsAuthorize("Admin", "List")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ClaimsAuthorize("Admin", "Users")]
        public async Task<IActionResult> Users(int pg = 1)
        {
            var users = await _userQuery.GetAll();

            //limit iten for page
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;

            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string actionName = ControllerContext.ActionDescriptor.ActionName;

            int totalItens = users.Count();
            var pager = new Pager(totalItens, pg, controllerName, actionName, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = users.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);
        }


        [ClaimsAuthorize("Admin", "Users")]
        public async Task<IActionResult> UsersDetails(Guid userid)
        {
            var userInfo = new UserInformationDTO();
            var user = await _userQuery.GetById(userid);
            if (user == null)
                _toastNotification.AddErrorToastMessage("An unexpected error occur, invalid User");

            var info = await _userInformationfoQuery.GetByUserId(user.Id);
            if (info == null)
            {
                userInfo.User = user;

                var friendList = await _userFriendQuery.GetByUserId(user.Id);
                userInfo.UserFriend = friendList.ToList();

                var commentsList = await _commentRepository.GetByUserId(user.Id);

                var totalReports = await _reportUserQuery.GetByUserId(user.Id);
                var totalScore =  _rankingQuery.TotalUserScore(user.Id);

                var topics = await _topicQuery.GetByUserCreatorId(user.Id);

                ViewBag.TotalFirends = friendList.Count();
                ViewBag.TotalPosts = commentsList.Count();
                ViewBag.TotalReports = totalReports.Count();
                ViewBag.TotalScore = totalScore;
                ViewBag.TotalTopicCreate = topics.Count();

                return View(userInfo);
            }
            else
            {
                userInfo = info;
                userInfo.User = user;

                var friendList = await _userFriendQuery.GetByUserId(user.Id);
                userInfo.UserFriend = friendList.ToList();
                var commentsList = await _commentRepository.GetByUserId(user.Id);

                var totalReports = await _reportUserQuery.GetByUserId(user.Id);
                var totalScore = _rankingQuery.TotalUserScore(user.Id);

                var topics = await _topicQuery.GetByUserCreatorId(user.Id);

                ViewBag.TotalFirends = friendList.Count();
                ViewBag.TotalPosts = commentsList.Count();
                ViewBag.TotalReports = totalReports.Count();
                ViewBag.TotalScore = totalScore;
                ViewBag.TotalTopicCreate = topics.Count();

                return View(userInfo);
            }

        }


        [ClaimsAuthorize("Admin", "Reports")]
        public async Task<IActionResult> UserReportsAll(int pg =1)
        {
            var reports = await _reportUserQuery.GetAll();

            //limit iten for page
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;

            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string actionName = ControllerContext.ActionDescriptor.ActionName;

            int totalItens = reports.Count();
            var pager = new Pager(totalItens, pg, controllerName, actionName, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = reports.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);

        }

        [HttpPost]

        [ClaimsAuthorize("Reports", "List")]
        public async Task<IActionResult> UserReports(Guid userid,string reason)
        {
            if (userid == Guid.Empty || string.IsNullOrEmpty(reason))
            {
                _toastNotification.AddErrorToastMessage("A error occured, invalid form data ");
                return RedirectToAction("Index", "Home");
            }

            var loggedUserName = User.Identity.Name;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserName);

            //current logged user
            var user = await _userQuery.GetByIdentityId(Guid.Parse(loggedUser.Id));

            var userReported = await _userQuery.GetById(userid);

            var command = new AddReportCommand(user.Id, userid, reason);
            await _mediatorHandler.SendCommand(command);

            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("You are reported " + userReported.Name);
                return RedirectToAction("Index", "User", new { loggedid = user.Id, profileid = userReported.IdentityId, isowner = 0 });
            }

            _toastNotification.AddErrorToastMessage("A error occured ");
            return RedirectToAction("Index", "User", new { loggedid = user.Id, profileid = userReported.IdentityId, isowner = 0 });

            return View();
        }


        [ClaimsAuthorize("Topics", "List")]
        public async Task<IActionResult> Topics(int pg =1)
        {
            var topics = await _topicQuery.GetAll();

            //limit iten for page
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;

            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string actionName = ControllerContext.ActionDescriptor.ActionName;

            int totalItens = topics.Count();
            var pager = new Pager(totalItens, pg, controllerName, actionName, pageSize);
            int rowSkip = (pg - 1) * pageSize;

            var data = topics.Skip(rowSkip).Take(pager.PageSize).ToList();
            ViewBag.Pagination = pager;
            ViewBag.Pager = new Pager();

            return View(data);
        }

        [HttpPost]
        [ClaimsAuthorize("Topics", "Delete")]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            if (topicId != Guid.Empty)
            {
                var command = new DeleteTopicCommand(topicId);
                await _mediatorHandler.SendCommand(command);
            }
            else
            {
                _toastNotification.AddErrorToastMessage("An error occur");
                return RedirectToAction("Topics");
            }

            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("Topic Deleted successfully");
                return RedirectToAction("Topics");
            }

            return   RedirectToAction("Topics");
        }

        [HttpPost]
        [ClaimsAuthorize("Admin", "Ban")]
        public async Task<IActionResult> BanUser(Guid userId)
        {

            var command = new BanUserCommand(userId); 
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("User was banned successfully.");
                return RedirectToAction("Users");
            }

            _toastNotification.AddSuccessToastMessage("An Error occur while try ban this user.");

            return RedirectToAction("Users");
        }

        [HttpPost]
        [ClaimsAuthorize("Admin", "UnBan")]
        public async Task<IActionResult> UnBanUser(Guid userId)
        {
            var command = new UnBanUserCommand(userId);
            await _mediatorHandler.SendCommand(command);


            if (IsvalidOpperation())
            {
                _toastNotification.AddSuccessToastMessage("Ban was Removed successfully.");
                return RedirectToAction("Users", "Admin");
            }

            _toastNotification.AddSuccessToastMessage("An Error occur while try remove ban this user.");

            return  RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> WeekBan(Guid userId)
        {
            return View();
        }
    }
}
