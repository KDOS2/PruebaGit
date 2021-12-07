namespace _57BlocksCRUD.BL
{
    using _57BlocksCRUD.Models;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class MoviesBL
    {
        private string path = string.Empty;
        private Token token = null;

        public MoviesBL(string path, string JWT_PASSWORD, string JWT_USUARIO, string PathToken)
        {
            this.path = path;
            this.token = new Token(PathToken, JWT_PASSWORD, JWT_USUARIO);
        }

        public MoviesModel GenderLoad(int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "GenderLoad?IdUser=" + UserId.ToString();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.GetAsync(sUrlApi2);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }

        public MoviesModel Insert(MoviesModel modelo, int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "InsertMovie";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.PostAsJsonAsync<MoviesModel>(sUrlApi2, modelo);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    MoviesModel var = JsonConvert.DeserializeObject<MoviesModel>(json);
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                }
                else
                    throw new Exception(json.ToString());
            }
        }

        public MoviesModel Delete(int idMovie, int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "DeleteMovie?IdMovie=" + idMovie.ToString() + "&IdUser="+ UserId.ToString();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.GetAsync(sUrlApi2);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }

        public MoviesModel Delete(int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "DeleteAllMyMovie?IdUser=" + UserId.ToString();
                client.BaseAddress = new Uri(sUrlApi2);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                var postTask = client.GetAsync(sUrlApi2);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }

        public MoviesModel AllMovies(int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "AllMovies?IdUser=" + UserId;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.GetAsync(sUrlApi2);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }

        public MoviesModel likes(int idMovie, int UserId, string email)
        {
            string json = string.Empty;
            object rta = 0;

            using (var client = new HttpClient())
            {
                ConfigurationBuilder _configuration = new ConfigurationBuilder();
                // Parametros de usuario al servicio de autenticación                
                string sUrlApi2 = this.path + "LikeMovies?IdMovie=" + idMovie.ToString() + "&IdUser=" + UserId.ToString();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token.Logintoken(email));
                client.BaseAddress = new Uri(sUrlApi2);
                var postTask = client.GetAsync(sUrlApi2);
                postTask.Wait();

                var result = postTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                json = readTask.Result;

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<MoviesModel>(json);
                else
                    throw new Exception(json.ToString());
            }
        }
    }
}
