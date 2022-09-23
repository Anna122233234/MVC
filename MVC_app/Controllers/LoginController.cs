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
            if (user.Login == null || user.Password == null)
            {
                return RedirectToAction("Index");
            }
            foreach (var record in GetUser())
            {
                if (user.Login == record.Login && user.Password == record.Password)
                {
                    user.Verif = true;
                    user.Admin = record.Admin;
                    return View("Checking", user);
                }
            }
            return View("Checking", user);
        }
        public List<UserModel> GetUser()
        {
            List<UserModel> users = new List<UserModel>
            {
                new UserModel { Login = "Anna", Password = "1337", Admin = false },
                new UserModel { Login = "Ann" , Password = "228", Admin = true },
                new UserModel { Login = "Ann1", Password = "5678", Admin = false },
                new UserModel { Login = "Ann2", Password = "4578", Admin = false },
                new UserModel { Login = "Ann3", Password = "1245", Admin = true },
                new UserModel { Login = "Ann4", Password = "7859", Admin = true }
            };
            return users;
        }

    }
}
