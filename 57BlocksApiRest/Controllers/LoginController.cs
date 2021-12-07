namespace _57BlocksApiRest.Controllers
{
    using _57BlocksApiRest.DBAcces;
    using _57BlocksApiRest.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text.RegularExpressions;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region "variables privadas"

        private string RegularExpressionEmail = string.Empty;

        #endregion

        #region "constructor"

        public LoginController(IOptions<OptionsEntity> myOptions)
        {
            this.RegularExpressionEmail = myOptions.Value.RegularExpressionEmail;
        }

        #endregion

        #region "metodos del controlador"

        /// <summary>
        /// realiza el login en la aplicacion
        /// </summary>
        /// <param name="login">datos para validacion del ingreso</param>
        /// <returns></returns>
        [HttpPost("LoginApp")]
        public UserRegisterEntity LoginApp(EntityLogin login)
        {
            try
            {
                string mensaje = string.Empty;

                if (!this.ValidarEmail(login.email))
                    mensaje = "Email is not valid";

                if (!this.ValidarPws(login.pws))
                    mensaje = !string.IsNullOrEmpty(mensaje) ? mensaje + " <br> Pasword is not valid: <br><tr> please Make sure your are typing a right pasword <br> " +
                                                                                "validate following: <br> it contains at least 10 characters." +
                                                                                "One lowercase letter." +
                                                                                "One uppercase letter." +
                                                                                "One of the following characters: !, @, #, ? or ]." : "Pasword is not valid: </br></tr> please Make sure your are typing a right pasword <br> " +
                                                                                "validate following: <br> it contains at least 10 characters." +
                                                                                "One lowercase letter." +
                                                                                "One uppercase letter." +
                                                                                "One of the following characters: !, @, #, ? or ].";

                if (string.IsNullOrEmpty(mensaje))
                    return this.Login(login);

                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// inserta registro en a base de datos
        /// </summary>
        /// <param name="data">objeto con la informacion a ser insertada</param>
        /// <returns></returns>
        [HttpPost("InsertUpdate")]
        public bool InsertUpdate(UserRegisterEntity data)
        {
            try
            {
                if(this.ValidateExistEmail(data))
                    return this.UpdateInsert(data);
                else
                    throw new Exception("*This email is already registered.*");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        

        #endregion

        #region "metodos privados"

        /// <summary>
        /// valida la estructura del email
        /// </summary>
        /// <param name="email">email a ser evaluado</param>
        /// <returns></returns>
        private bool ValidarEmail(string email)
        {
            return Regex.IsMatch(email, RegularExpressionEmail, RegexOptions.IgnoreCase); ;
        }

        /// <summary>
        /// Valida que la estructura del password sea correcta
        /// </summary>
        /// <param name="pws">objeto que contiene el password a ser evaluado</param>
        /// <returns></returns>
        private bool ValidarPws(string pws)
        {
            if (pws.Length >= 10 && pws.Where(char.IsUpper).Count() >= 1 && pws.Where(char.IsLower).Count() >= 1 &&
               (pws.Contains("!") || pws.Contains("@") || pws.Contains("#") || pws.Contains("?") || pws.Contains("]")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// metodo que se encarga de logear al usuario
        /// </summary>
        /// <param name="data">objeto que tiene las credenciales del usuario</param>
        /// <returns></returns>
        private UserRegisterEntity Login(EntityLogin data)
        {
            EntitySql param = new EntitySql();
            param.query = "select  UserId, UserName, UserlastName, email, pws from Users where email = '" + data.email + "' and pws = '" + data.pws + "';";
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);
            
            UserRegisterEntity user = new UserRegisterEntity();

            if (!tabla.Rows.Count.Equals(0))
            {
                user.UserId = Convert.ToInt32(tabla.Rows[0]["UserId"].ToString());
                user.UserName = tabla.Rows[0]["UserName"].ToString();
                user.UserlastName = tabla.Rows[0]["UserlastName"].ToString();
                user.email = tabla.Rows[0]["email"].ToString();
                user.pws = tabla.Rows[0]["pws"].ToString();
            }

            return user;
        }

        /// <summary>
        /// relaiza las inserciones
        /// </summary>
        /// <param name="data"> objeto que contiene la informacion a ser registrada </param>
        /// <returns></returns>
        private bool UpdateInsert(UserRegisterEntity data)
        {
            if (this.ValidarPws(data.pws))
            {
                EntitySql param = new EntitySql();
                param.query = "insert into Users(UserName, UserlastName, email, pws) values('" + data.UserName + "', '" + data.UserlastName + "', '" + data.email + "', '" + data.pws + "')";
                param.param = new List<param>();
                param.values = new List<values>();

                return DBO.Insert(param);
            }
            else
                throw new Exception("*Pasword is not valid: please Make sure your are typing a right pasword " +
                                    "validate following: it contains at least 10 characters. " +
                                    "One lowercase letter. " +
                                    "One uppercase letter " +
                                    "One of the following characters: !, @, #, ? or ].*");
        }

        /// <summary>
        /// metodo que se valida que un email no este registrado previamente
        /// </summary>
        /// <param name="data">objeto que tiene las credenciales del usuario</param>
        /// <returns></returns>
        private bool ValidateExistEmail(UserRegisterEntity data)
        {
            EntitySql param = new EntitySql();
            param.query = "select  count(1) from Users where email = '" + data.email + "';";
            param.param = new List<param>();
            param.values = new List<values>();
            DataTable tabla = DBO.Select(param);

            if(Convert.ToInt32(tabla.Rows[0][0].ToString()).Equals(0))
                return true;
            else
                return false;
        }

        #endregion
    }
}
