using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _57BlocksCRUD.Entities
{
    public class OptionsEntity
    {
        public const string SectionName = "MySettings";

        public string PathApi { get; set; }

        public string PathApiMovie { get; set; }

        public int timeOff { get; set; }

        public string PathToken { get; set; }

        public string JWT_USUARIO { get; set; }

        public string JWT_PASSWORD { get; set; }
    }
}
