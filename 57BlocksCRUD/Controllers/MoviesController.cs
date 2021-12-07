namespace _57BlocksCRUD.Controllers
{
    using _57BlocksCRUD.BL;
    using _57BlocksCRUD.Entities;
    using _57BlocksCRUD.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MoviesController : Controller
    {
        private string pathApi = string.Empty;
        private int timeOff = 0;
        private string PathToken = string.Empty;
        private string JWT_USUARIO = string.Empty;
        private string JWT_PASSWORD = string.Empty;

        public MoviesController(IOptions<OptionsEntity> myOptions)
        {
            this.timeOff = myOptions.Value.timeOff;
            this.pathApi = myOptions.Value.PathApiMovie;
            this.PathToken = myOptions.Value.PathToken;
            this.JWT_USUARIO = myOptions.Value.JWT_USUARIO;
            this.JWT_PASSWORD = myOptions.Value.JWT_PASSWORD;
        }

        /// <summary>
        /// carga la vista una vez se ingresa 
        /// </summary>
        /// <returns></returns>
        // GET: MoviesController
        public ActionResult Index()
        {
            
            MoviesModel movies = new MoviesModel();
            
            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    movies = operation.GenderLoad(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = false;
                    return View("Index", movies);
                }
            }
            catch(Exception e)
            {
                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("Index", movies);
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoviesModel modelo)
        {
            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    modelo.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    modelo.Gender = new List<GenderEntity>();
                    modelo.DataShow = new List<Movies>();
                    MoviesModel movies = operation.Insert(modelo, Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = true;
                    TempData["msg"] = modelo.id.Equals(0) ? "This data was inserted successfully." : "This data was updated successfully.";
                    return View("Index", movies);
                }
            }
            catch(Exception e)
            {
                MoviesModel movies = new MoviesModel();

                MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                movies = operation.GenderLoad(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                movies.DataShow = new List<Movies>();

                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("Index", movies);
            }
        }
                
        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    MoviesModel movies = operation.Delete(id, Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = true;
                    TempData["msg"] = "This data was deleted successfully.";
                    return View("Index", movies);
                }
            }
            catch (Exception e)
            {
                MoviesModel movies = new MoviesModel();

                MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                movies = operation.GenderLoad(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                movies.DataShow = new List<Movies>();

                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("Index", movies);
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult DeleteAllMyMovies(int id)
        {
            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    MoviesModel movies = operation.Delete(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = true;
                    TempData["msg"] = "This data was deleted successfully.";
                    return View("Index", movies);
                }
            }
            catch (Exception e)
            {
                MoviesModel movies = new MoviesModel();

                MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                movies = operation.GenderLoad(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                movies.DataShow = new List<Movies>();

                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("Index", movies);
            }
        }

        public ActionResult AllMovies()
        {

            MoviesModel movies = new MoviesModel();

            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    movies = operation.AllMovies(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = false;
                    return View("AllMovies", movies);
                }
            }
            catch (Exception e)
            {
                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("AllMovies", movies);
            }
        }

        /// <summary>
        /// carga la vista una vez se ingresa 
        /// mostrando todas las peliculas almacenadas
        /// </summary>
        /// <returns></returns>
        // POST: MoviesController/Edit/5
        [HttpGet]
        public ActionResult LikesMovie(int id)
        {

            MoviesModel movies = new MoviesModel();

            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    movies = operation.likes(id, Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                    TempData["showGrid"] = true;
                    return View("AllMovies", movies);
                }
            }
            catch (Exception e)
            {
                MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                movies = operation.AllMovies(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));
                movies.DataShow = new List<Movies>();

                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("AllMovies", movies);
            }
        }

        /// <summary>
        /// carga la vista una vez se ingresa 
        /// mostrando todas las peliculas almacenadas
        /// </summary>
        /// <returns></returns>
        // GET: MoviesController
        public ActionResult AllMoviesFilter(int? filter = null)
        {

            MoviesModel movies = new MoviesModel();

            try
            {
                this.SesionValidate();

                if (HttpContext.Session.Keys.Count().Equals(0))
                    return RedirectToAction("Index", "Login");
                else
                {
                    MoviesBL operation = new MoviesBL(this.pathApi, this.JWT_PASSWORD, this.JWT_USUARIO, this.PathToken);
                    movies = operation.AllMovies(Convert.ToInt32(HttpContext.Session.GetInt32("userId")), HttpContext.Session.GetString("email"));

                    if (filter.Equals(1))
                        movies.DataShow = movies.DataShow.Where(a => a.likeIt.Equals(true)).ToList();

                    TempData["showGrid"] = false;
                    return View("AllMovies", movies);
                }
            }
            catch (Exception e)
            {
                string[] message = e.Message.Split('*');
                string msgFin = message.Length > 1 ? message[1] : message[0];
                TempData["msgError"] = "Error -> " + msgFin;
                return View("AllMovies", movies);
            }
        }


        /// <summary>
        /// valida si han transcurrido 20 min 
        /// si es asi limpia la sesion
        /// </summary>
        private void SesionValidate()
        {

            var min = (DateTime.Now - Convert.ToDateTime(HttpContext.Session.GetString("date"))).TotalMinutes;
            if (min >= timeOff)
                HttpContext.Session.Clear();
        }
    }
}
