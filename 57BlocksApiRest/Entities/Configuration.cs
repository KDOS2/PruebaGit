namespace _57BlocksApiRest.Entities
{
    public class Configuration_
    {
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public string JWT_EXPIRE_MINUTES { get; set; }
    }
}
