using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Areas.Admin.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public string UserName { get; set; }
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
                Username = this.UserName,
                Password = this.Password
            };

            var loginData = loginRepository.GetData(login);

            if (loginData.Result != null)
            {
               // HttpContext.Session.SetString("username", UserName);
                return RedirectToPage("Create");
            }
            else
            {
                Message = "Invalid Login";
                return Page();
            }
        }
    }
}
