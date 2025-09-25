using Microsoft.AspNetCore.Http.Features;
using Navistar.Utils.Core;
using System;

namespace Navistar.Web.API.Providers
{
    public interface ISecurity
    {
        void SetCredentials(IServerVariablesFeature serverVariables);

        String GetUser();
    }

    public class Security : ISecurity
    {
        String user = Constants.EMPTY_STRING;

        public Security()
        {
        }

        public void SetCredentials(IServerVariablesFeature serverVariables)
        {
            try
            {
                String usuarioServidor = serverVariables != null ? serverVariables["AUTH_USER"] : null;

                this.user = Constants.EMPTY_STRING;
                if (usuarioServidor != null && !String.IsNullOrEmpty(usuarioServidor))
                {
                    this.user = usuarioServidor;
                }
                else if (serverVariables != null)
                {
                    usuarioServidor = serverVariables["HTTP_IV_USER"];
                    this.user = (usuarioServidor == null || String.IsNullOrEmpty(usuarioServidor)) ? user : usuarioServidor;
                }
                else
                {
                    this.user = "NAVISTAR\\yyy3v57"; // User Dev
                }

                Console.WriteLine("this.user: " + this.user);
                this.user = StringUtility.RemoverDominio(this.user);
            }
            catch (Exception e)
            {
                Console.WriteLine("Security - SetCredentials: " + e.Message);
                this.user = Constants.EMPTY_STRING;
            }
        }

        public string GetUser()
        {
            return this.user;
        }

    }
}
