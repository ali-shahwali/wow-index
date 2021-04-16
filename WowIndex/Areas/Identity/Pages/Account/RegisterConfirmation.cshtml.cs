using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System;
using Amazon.SimpleEmail;
using Amazon.Runtime;
using Amazon;
using Amazon.SimpleEmail.Model;
using System.Collections.Generic;

namespace WowIndex.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<IdentityUser> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailClient = new AmazonSimpleEmailServiceClient(
                new BasicAWSCredentials("AKIAZUIGJ2R6LZV4LIAU", "hVZdbYNcll48Sw852E7aFwjx1LX02lYg7tAmq8us"),
                RegionEndpoint.EUNorth1);

            string data = $@"{{""link"": ""{code}""}}";

            var sendRequest = new SendTemplatedEmailRequest
            {
                Source = $"WowIndex <ali_zinq@hotmail.com>",
                Destination = new Destination { ToAddresses = new List<string> { Email } },
                Template = "wowindex",
                TemplateData = data,
            };

            var response = await emailClient.SendTemplatedEmailAsync(sendRequest);

            return Page();
        }
    }
}
