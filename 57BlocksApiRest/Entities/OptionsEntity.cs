using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57BlocksApiRest.Entities
{
    public class OptionsEntity
    {
        public const string SectionName = "MySettings";
        public string RegularExpressionEmail { get; set; }
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public string JWT_EXPIRE_MINUTES { get; set; }
    }
}
