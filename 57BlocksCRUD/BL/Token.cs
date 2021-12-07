using _57BlocksCRUD.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace _57BlocksCRUD.BL
{
    public class Token
    {
        private string PathToken = string.Empty;
        private string JWT_USUARIO = string.Empty;
        private string JWT_PASSWORD = string.Empty;

        public Token(string PathToken, string JWT_PASSWORD, string JWT_USUARIO)
        {
            this.PathToken = PathToken;
            this.JWT_USUARIO = JWT_USUARIO;
            this.JWT_PASSWORD = JWT_PASSWORD;
        }

        /// <summary>
        /// se utiliza para realizar las peticiones al servicio res que consume CPP para todas sus consultas a la base de datos
        /// </summary>
        /// <returns></returns>
        public string Logintoken(string email)
        {

            // Definición de variables
            string json = string.Empty;
            string token = string.Empty;

            using (var client = new HttpClient())
            {
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.PathToken + "authenticate";
                client.BaseAddress = new Uri(sUrlApi2);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var login = new LoginRequest() { email = email };
                var postTask = client.PostAsJsonAsync<LoginRequest>(sUrlApi2, login);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // Retorno consulta Json
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    json = readTask.Result;
                    token = JsonConvert.DeserializeObject<string>(json);
                }
            }
            return token;
        }
    }
}
