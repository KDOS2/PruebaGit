namespace _57BlocksCRUD.Controllers
{
    using _57BlocksCRUD.BL;
    using _57BlocksCRUD.Entities;
    using _57BlocksCRUD.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;

    public class UserRegisterController : Controller
    {
        private string pathApi = string.Empty;
        public UserRegisterController(IOptions<OptionsEntity> myOptions)
        {
            this.pathApi = myOptions.Value.PathApi;
        }

        // GET: UserRegisterController
        public ActionResult Index()
        {
            return View();
        }

        // POST: UserRegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegisterModel userRegister)
        {
            try
            {
                UserRegisterBL operation = new UserRegisterBL(this.pathApi, string.Empty, string.Empty, string.Empty);
                operation.Insert(userRegister);
                TempData["msg"] = "This data was inserted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("Index",userRegister);
            }
        }        
    }
}
