namespace _57BlocksCRUD.Controllers
{
    using _57BlocksCRUD.BL;
    using _57BlocksCRUD.Entities;
    using _57BlocksCRUD.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Linq;

    public class LogInController : Controller
    {
        private string pathApi = string.Empty;
        private int timeOff = 0;
        private string PathToken = string.Empty;
        private string JWT_USUARIO = string.Empty;
        private string JWT_PASSWORD = string.Empty;

        public LogInController(IOptions<OptionsEntity> myOptions)
        {
            this.timeOff = myOptions.Value.timeOff;
            this.pathApi = myOptions.Value.PathApi;
            this.PathToken = myOptions.Value.PathToken;
            this.JWT_USUARIO = myOptions.Value.JWT_USUARIO;
            this.JWT_PASSWORD = myOptions.Value.JWT_PASSWORD;
        }

        // GET: LogInController
        public ActionResult Index()
        {
            this.SesionValidate();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel login)
        {
            try
            {
                UserRegisterBL operation = new UserRegisterBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                UserRegisterModel users = operation.LogIn(login);
                if (users.Equals(null))
                   TempData["msg"] = "User don't exist into the system";
                else
                { 
                    TempData["msg"] = "You has logged succesfully.";
                    login.date = DateTime.Now;
                    login.hour = DateTime.Now.Hour;
                    HttpContext.Session.SetInt32("userId", users.UserId);
                    HttpContext.Session.SetString("email", users.email);
                    HttpContext.Session.SetString("userName", users.UserName + " "+ users.UserlastName);
                    HttpContext.Session.SetString("date", DateTime.Now.ToString());                
                }                

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// valida si han transcurrido 20 min 
        /// si es asi limpia la sesion
        /// </summary>
        private void SesionValidate()
        {
            if (HttpContext != null && HttpContext.Session.GetString("date") != null)
            {
                var min = (DateTime.Now - Convert.ToDateTime(HttpContext.Session.GetString("date"))).TotalMinutes;
                if (min >= timeOff)
                    HttpContext.Session.Clear();
            }            
        }

    }
}
