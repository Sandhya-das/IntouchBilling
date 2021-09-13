using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public string Username { get; set; }
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

        }
        public IActionResult OnPost()
        {
            Entity.Login login = new Entity.Login
            {
                Username = this.Username,
                //Password = "test@123"
                Password =  this.Password
            };

            var loginData = loginRepository.GetData(login);
            int loginId = loginData.Result.LoginId;
            
            if (loginData.Result != null)
            {
                // HttpContext.Session.SetString("username", UserName);
                return RedirectToPage("Billing",new { id = loginId });
            }
            else
            {
                Message = "Invalid Login";
                return Page();
            }
        }
    }
}
