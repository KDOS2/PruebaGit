namespace _57BlocksCRUD.BL
{
    using _57BlocksCRUD.Entities;
    using _57BlocksCRUD.Models;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class UserRegisterBL
    {
        private string path = string.Empty;
        private Token token = null;

        public UserRegisterBL(string path, string JWT_PASSWORD, string JWT_USUARIO, string PathToken)
        {
            this.path = path;
            this.token = new Token(PathToken, JWT_PASSWORD, JWT_USUARIO);
        }

        public bool Insert(UserRegisterModel modelo)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "InsertUpdate";
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.PostAsJsonAsync<UserRegisterModel>(sUrlApi2, modelo);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<bool>(json);
                else
                    throw new Exception(json.ToString());
            }
        }

        public UserRegisterModel LogIn(LoginModel modelo)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "LoginApp";
                client.BaseAddress = new Uri(sUrlApi2);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(modelo.email));
                var postTask = client.PostAsJsonAsync<LoginModel>(sUrlApi2, modelo);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<UserRegisterModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }
    }
}

