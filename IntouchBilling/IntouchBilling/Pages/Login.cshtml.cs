using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Message { get; set; }

        private readonly ILoginRepository loginRepository;

        [BindProperty]
        public List<Entity.Login> LoginData { get; set; }

        public LoginModel(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public void OnGet()
        {
            HttpContext.Session.Remove("username");
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Entity.Login login = new Entity.Login
                {
                    Username = this.Username,
                    Password = this.Password
                };

                var loginData = loginRepository.GetData(login);

                if (loginData.Result != null)
                {
                  
                    HttpContext.Session.SetString("loginID", loginData.Result.LoginId.ToString());
                    HttpContext.Session.SetString("username", loginData.Result.Username);
                    return RedirectToPage("Billing");
                }
                else
                {
                    Message = "Invalid Login";
                    return Page();

                }

            }
            return Page();
        }
    }
}
