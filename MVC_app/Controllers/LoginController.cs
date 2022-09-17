using Microsoft.AspNetCore.Mvc;
using MVC_app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace MVC_app.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
        public IActionResult Check(UserModel user)
        {
            try
            {
                user.login = this.Request.Form["login"];
                user.password = this.Request.Form["password"];
            }
            catch
            {
                return RedirectToAction("Index");
            }
            foreach (var record in GetUser())
            {
                if (user.login == record.login && user.password == record.password)
                {
                    user.verif = true;
                    user.admin = record.admin;
                    return View("Checking", user);
                }
            }
            return View("Checking", user);
        }
        public List<UserModel> GetUser()
        {
            List<UserModel> users = new List<UserModel>
            {
                new UserModel { login = "Anna", password = "1337", admin = false },
                new UserModel { login = "Ann" , password = "228", admin = true },
                new UserModel { login = "Ann1", password = "5678", admin = false },
                new UserModel { login = "Ann2", password = "4578", admin = false },
                new UserModel { login = "Ann3", password = "1245", admin = true },
                new UserModel { login = "Ann4", password = "7859", admin = true }
            };
            return users;
        }

    }
}
