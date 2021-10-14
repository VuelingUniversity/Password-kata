using MyOwnTestsOnControllerMVC.Models;
using PasswordKata.Core.Services;
using PasswordKata.Infra;
using PasswordKata.ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOwnTestsOnControllerMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            List<string> userList = _userService.GetUsers();
            return View(userList);
        }

        public ActionResult Logging(string username)
        {
            var user = new User { Name = username, Password = "" };
            return View(user);
        }

        [HttpPost]
        public ActionResult TryToLog(User user)
        {
            var isCorrect = _userService.CheckUser(user.Name, user.Password);
            if (isCorrect)
            {
            }
            return RedirectToAction("Index");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User username)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}