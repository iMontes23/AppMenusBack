using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Response.ApiModels
{
    public class ApiLoginResponse
    {
        public LoginResponse response { get; set; }
    }

    public class LoginResponse
    {
        public LoginProperties properties { get; set; }
    }

    public class LoginProperties
    {
        public string action_name { get; set; }

        public List<LoginData> data { get; set; }
        public string action_value { get; set; }
        public string description { get; set; }
        public string session_token { get; set; }
    }

    public class LoginData
    {
        public string session_token { get; set; }
        public string profile_name { get; set; }
        public string language { get; set; }
        public string application_url { get; set; }
        public string map_type { get; set; }
    }

}
