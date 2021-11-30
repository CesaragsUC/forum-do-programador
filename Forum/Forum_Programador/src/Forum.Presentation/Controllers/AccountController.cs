using EmailService;
using Forum.Application.Commands.UserFirend;
using Forum.Application.DTO.Identity;
using Forum.Application.Queries.Interfaces;
using Forum.Core.Communication.Mediator;
using Forum.Core.Messages.CommonMessage.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;

namespace Forum.Presentation.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ITopicQuery _topicQuery;
        private readonly ISectionQuery _sectionQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly IUserQuery _userQuery;
        private readonly IEmailSender _emailSender;
        private readonly IToastNotification _toastNotification; 
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ITopicQuery topicQuery,
            ISectionQuery sectionQuery,
            ICommentQuery commentQuery,
            IUserQuery userQuery,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender,
            IToastNotification toastNotification) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _topicQuery = topicQuery;
            _sectionQuery = sectionQuery;
            _commentQuery = commentQuery;
            _userQuery = userQuery;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _toastNotification = toastNotification;
        }


        [AllowAnonymous]
        public async Task<ActionResult> Register()
        {
           
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid) return View(registerUser);

            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            var user = new IdentityUser
            {
                UserName = registerUser.Name,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                var command = new AddUserCommand(Guid.Parse(user.Id), registerUser.Name, registerUser.Email, 3);
                await _mediatorHandler.SendCommand(command);

                await _signInManager.SignInAsync(user, false);
            }

            // if (IsvalidOpperation())
            return RedirectToAction("Home", "Index");

        }


        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl)
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);

            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            IdentityUser user = null;
            if (!string.IsNullOrEmpty(loginUser.Email))
            {
                if (loginUser.Email.Contains("@"))
                    user = await _userManager.FindByEmailAsync(loginUser.Email);
                else
                    user = await _userManager.FindByNameAsync(loginUser.Email);

            }
            else if (!string.IsNullOrEmpty(loginUser.UserName))
            {
                user = await _userManager.FindByNameAsync(loginUser.UserName);
            }
            else
            {

                ModelState.AddModelError("Password", "The email and password is required");
                return View(loginUser);
            }


            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    _toastNotification.AddErrorToastMessage("User temporarily blocked by invalid attempts");
                    return View(loginUser);
                }

                _toastNotification.AddErrorToastMessage("User or pass incorrect");
                return View(loginUser);

            }
            else
            {
                _toastNotification.AddErrorToastMessage("User not found or is not registred");
                return View(loginUser);
            }


        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<bool> IsUserNameOrEmailExist(RegisterUserDTO loginUser)
        {
            if (!string.IsNullOrEmpty(loginUser.Name)
                && !string.IsNullOrEmpty(loginUser.Email)
                && !string.IsNullOrEmpty(loginUser.Password))
            {
                var result = await _userQuery.GetByNameAndEmail(loginUser.Name, loginUser.Email);
                if (result != null)
                    return true;
            }
            return false;

        }


        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IdentityUser user = null;
            try
            {
                user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage("User not found");
                    return RedirectToAction("ForgotPassword");
                }

            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error has occurred");
                return RedirectToAction("ForgotPassword");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = $"https://localhost:44308/Account/ResetPassword?token={token}&email={user.Email}";
                

            try
            {
                var message = new Message(new string[] { user.Email }, "Forum Nerd - Reset Password", callbackUrl, null);
                await _emailSender.SendEmailAsync(message);

                TempData["ForgotPasswordSent"] = "[+] The link has been sent, please check your email to reset your password.";
                return View();

            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage("An unexpected error has occurred");
                return View();
            }


        }



        public async Task<ActionResult> ResetPassword(string token,string email)
        {
            if (string.IsNullOrEmpty(token) && string.IsNullOrEmpty(email))
                return View("Error");



            var model = new ResetPasswordDTO
            {
                Email = email,
                Token = token.Replace("%20", "+").Replace(" ", "+")//remove all space(%20) and %2F(=) from token

            };

            return  View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            IdentityUser user = null;
            //depois q clica na url recebida no email e tenta submeter o form ele manda caracteres especias na url,
            //então temos q remove-las e tratar.
            //%20 = espaço.
            //%2F =
            var token = model.Token.Replace("%20", "+").Replace(" ", "+");

            user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                _toastNotification.AddErrorToastMessage("An error occour while reset password");
                return View(model);
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                _toastNotification.AddErrorToastMessage("An error occour while reset password");
                return View(model);
            }
            _toastNotification.AddSuccessToastMessage("Password was redefined successfully");
            return RedirectToAction("Login", "Account");


        }
    }
}
