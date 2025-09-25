using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.Request.ApiModels
{
    public class ApiLoginRequest
    {
        public LoginAction action { get; set; }
    }

    public class LoginAction
    {
        public string name { get; set; }

        public LoginParameters parameters { get; set; }
    }

    public class LoginParameters
    {
        public string login_name { get; set; }
        public string password { get; set; }
    }
}
