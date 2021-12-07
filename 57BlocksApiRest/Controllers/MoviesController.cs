namespace _57BlocksApiRest.Controllers
{
    using _57BlocksApiRest.DBAcces;
    using _57BlocksApiRest.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        [HttpGet("GenderLoad")]
        public MoviesModel GenderLoad(int IdUser)
        {
            try
            {
                MoviesModel movies = new MoviesModel();
                movies.Gender = new List<GenderEntity>();
                movies.Gender = this.LoadGender(null);
                movies.DataShow = this.LoadMovies(null, IdUser).DataShow;
                return movies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("InsertMovie")]
        public MoviesModel InsertEditMovie(MoviesModel modelo)
        {
            MoviesModel moviesModel = new MoviesModel();
            try
            {
                if (this.EditInsertMovies(modelo))
                    moviesModel = this.LoadMovies(modelo, null);

                moviesModel.Gender = new List<GenderEntity>();
                moviesModel.Gender = this.LoadGender(null);
                moviesModel.Duration = 0;
                moviesModel.MovieName = string.Empty;
                moviesModel.GenderId = 0;

                return moviesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("DeleteMovie")]
        public MoviesModel DeleteMovie(int IdMovie, int IdUser)
        {
            MoviesModel moviesModel = new MoviesModel();
            try
            {
                if (this.Delete(IdMovie))
                    moviesModel = this.LoadMovies(null, IdUser);

                moviesModel.Gender = new List<GenderEntity>();
                moviesModel.Gender = this.LoadGender(null);
                moviesModel.Duration = 0;
                moviesModel.MovieName = string.Empty;
                moviesModel.GenderId = 0;

                return moviesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("DeleteAllMyMovie")]
        public MoviesModel DeleteAllMyMovie(int IdUser)
        {
            MoviesModel moviesModel = new MoviesModel();
            try
            {
                if (this.DeleteAllMyMovies(IdUser))
                    moviesModel = this.LoadMovies(null, IdUser);

                moviesModel.Gender = new List<GenderEntity>();
                moviesModel.Gender = this.LoadGender(null);
                moviesModel.Duration = 0;
                moviesModel.MovieName = string.Empty;
                moviesModel.GenderId = 0;

                return moviesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("AllMovies")]
        public MoviesModel AllMovies(int IdUser, int page, int atras_adelante, int? idMovie = null)
        {
            try
            {
                MoviesModel moviesModel = new MoviesModel();
                moviesModel = this.LoadAllMovies();
                this.LoadLikeByMovie(IdUser, moviesModel);
                return moviesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("LikeMovies")]
        public MoviesModel LikeMovies(int IdMovie, int IdUser, int page, int atras_adelante)
        {
            try
            {
                MoviesModel moviesModel = new MoviesModel();
                if (this.InsertLike(IdMovie, IdUser))
                    moviesModel = this.LoadAllMovies();

                this.LoadLikeByMovie(IdUser, moviesModel);

                return moviesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #region"Metodos privados"

        /// <summary>
        /// metodo que se encarga de cargar los generos de las peliculas
        /// </summary>
        /// <returns></returns>
        private List<GenderEntity> LoadGender(int? idGenenero = null)
        {
            EntitySql param = new EntitySql();
            
            if(idGenenero.Equals(null))
                param.query = "select GenderId, GenderDescription from MovieGender order by GenderDescription;";
            else
                param.query = "select GenderId, GenderDescription from MovieGender where GenderId = " + idGenenero.ToString() + " order by GenderDescription;";

            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            GenderEntity movieGender = new GenderEntity();
            List<GenderEntity> movieGenderLst = new List<GenderEntity>();

            foreach (DataRow item in tabla.Rows)
            {
                movieGender = new GenderEntity();
                movieGender.GenderId = Convert.ToInt32(item["GenderId"].ToString());
                movieGender.GenderDescription = item["GenderDescription"].ToString();
                movieGenderLst.Add(movieGender);
            }

            return movieGenderLst;
        }

        /// <summary>
        /// metodo que se encarga de insertar un nuevo registro
        /// </summary>
        /// <returns></returns>
        private bool EditInsertMovies(MoviesModel modelo)
        {
            EntitySql param = new EntitySql();
            if(modelo.id.Equals(0))
                param.query = "insert into Movies(MovieName, Gender, Duration, UserId) values ('"+ modelo.MovieName + "', '"+modelo.GenderId.ToString()+"', " + modelo.Duration.ToString() + ", " + modelo.UserId.ToString() + ")";
            else
                param.query = "update Movies set MovieName = '" + modelo.MovieName + "', Gender = " + modelo.GenderId.ToString() + ", Duration = "+ modelo.Duration.ToString() + " where id = " + modelo.id.ToString();

            param.param = new List<param>();
            param.values = new List<values>();
            
            return DBO.Insert(param);
        }

        /// <summary>
        /// metodo que se encarga de consultar todos los registros
        /// </summary>
        /// <returns></returns>
        private MoviesModel LoadMovies(MoviesModel? model = null, int? UserId = null)
        {
            EntitySql param = new EntitySql();
            
            if(model == null && UserId.Equals(null))
                param.query = "select id, MovieName, Gender, Duration, UserId from Movies order by MovieName";
            else if(model != null)
                param.query = "select id, MovieName, Gender, Duration, UserId from Movies where UserId = " + model.UserId.ToString() + " order by MovieName;";
            else
                param.query = "select id, MovieName, Gender, Duration, UserId from Movies where UserId = " + UserId.ToString() + " order by MovieName;";

            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            MoviesModel movie = new MoviesModel();
            movie.DataShow = new List<Movies>();
            Movies movie2 = null;

            foreach (DataRow item in tabla.Rows)
            {
                movie2 = new Movies();
                movie2.id = Convert.ToInt32(item["id"].ToString());
                movie2.MovieName = item["MovieName"].ToString();
                movie2.GenderId = Convert.ToInt32(item["Gender"].ToString());
                movie2.Gender = this.LoadGender(movie2.GenderId);
                movie2.Duration = Convert.ToDouble(item["Duration"].ToString());
                movie2.UserId = Convert.ToInt32(item["UserId"].ToString());
                movie.DataShow.Add(movie2);
            }

            return movie;
        }

        /// <summary>
        /// metodo que elimina una pelicula
        /// </summary>
        /// <returns></returns>
        private bool Delete(int idMovie)
        {
            EntitySql param = new EntitySql();
            param.query = "select idMovie from MoviesLike where idMovie = " + idMovie.ToString();
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            if (!tabla.Rows.Count.Equals(0))
            {
                foreach (DataRow row in tabla.Rows)
                {
                    param.query = "delete from MoviesLike where idMovie = " + row["idMovie"].ToString();
                    param.param = new List<param>();
                    param.values = new List<values>();
                    DBO.Insert(param);
                }
            }

            param.query = "delete from Movies where id = " + idMovie.ToString();
            param.param = new List<param>();
            param.values = new List<values>();

            return DBO.Insert(param);
        }

        /// <summary>
        /// metodo que elimina todas la peliculas asociadas a un usuario
        /// </summary>
        /// <returns></returns>
        private bool DeleteAllMyMovies(int idUser)
        {
            EntitySql param = new EntitySql();
            param.query = "select id from Movies where UserId = " + idUser.ToString();
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            if (!tabla.Rows.Count.Equals(0))
            {
                foreach (DataRow row in tabla.Rows)
                {
                    param.query = "delete from MoviesLike where idMovie = " + row["id"].ToString();
                    param.param = new List<param>();
                    param.values = new List<values>();
                    DBO.Insert(param);
                }
            }

            param.query = "delete from Movies where UserId = " + idUser.ToString();
            param.param = new List<param>();
            param.values = new List<values>();

            return DBO.Insert(param);
        }

        /// <summary>
        /// metodo que se encarga de consultar todos los registros
        /// solo las peliculas a ser consultadas
        /// </summary>
        /// <returns></returns>
        private MoviesModel LoadAllMovies()
        {
            EntitySql param = new EntitySql();
            param.param = new List<param>();
            param.values = new List<values>();

            param.query = "select id, MovieName, Gender, Duration, UserId from Movies order by MovieName";

            DataTable tabla = DBO.Select(param);

            MoviesModel movie = new MoviesModel();
            movie.DataShow = new List<Movies>();
            movie.Gender = new List<GenderEntity>();
            Movies movie2 = null;
            bool primero = false;

            foreach (DataRow item in tabla.Rows)
            {
                movie2 = new Movies();
                movie2.id = Convert.ToInt32(item["id"].ToString());
                movie2.MovieName = item["MovieName"].ToString();
                movie2.GenderId = Convert.ToInt32(item["Gender"].ToString());
                movie2.Gender = this.LoadGender(movie2.GenderId);
                movie2.Duration = Convert.ToDouble(item["Duration"].ToString());
                movie2.UserId = Convert.ToInt32(item["UserId"].ToString());
                movie.DataShow.Add(movie2);                
            }

            return movie;
        }

        /// <summary>
        /// metodo que se encarga de insertar un nuevo registro
        /// </summary>
        /// <returns></returns>
        private bool InsertLike(int idMovie, int IdUser)
        {
            EntitySql param = new EntitySql();

            param.query = "select count(1) from MoviesLike where idUser = " + IdUser.ToString() + " and idMovie = " + idMovie.ToString();
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            if(Convert.ToInt32(tabla.Rows[0][0].ToString()).Equals(0))
                param.query = "insert into MoviesLike(idMovie, idUser) values (" + idMovie.ToString() + ", " + IdUser.ToString() + ")";
            else
                param.query = "delete from MoviesLike where idUser = " + IdUser.ToString() + " and idMovie = " + idMovie.ToString();

            param.param = new List<param>();
            param.values = new List<values>();

            return DBO.Insert(param);
        }

        /// <summary>
        /// Valida las peliculasa las cuales el usuario le dio like
        /// </summary>
        /// <param name="idUser">is usuario</param>
        /// <param name="moviesModel">modelo con las peliculas pre cargadas</param>
        /// <returns></returns>
        private void LoadLikeByMovie(int idUser, MoviesModel moviesModel)
        {
            EntitySql param = new EntitySql();

            param.query = "select idLike, idMovie, idUser from MoviesLike where idUser = "+ idUser.ToString();


            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            foreach (Movies data in moviesModel.DataShow)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    if (data.id.Equals(Convert.ToInt32(row["idMovie"])))
                    {
                        data.likeIt = true;
                        break;
                    }
                    else
                        data.likeIt = false;
                }
            }
        }

        #endregion
    }
}
