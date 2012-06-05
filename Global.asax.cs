using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EnvTestApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // TODO: Bootstrap the environment variables from a config file
            //       that lives outside of the application somewhere on the server.

            // Look for the environment config file just outside where the app is running from.
            // Example: If c:\inetpub\wwwroot\MyApp\bin is the assembly location, look for
            //          the config file in c:\inetpub\wwwroot\MyApp.envConfig.txt
            // The AppPool will have to have read access to this file.
            var appRootDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            string envConfigFile = Path.Combine(appRootDir.Parent.FullName, string.Format("{0}.envConfig.txt", appRootDir.Name));
            if (File.Exists(envConfigFile))
            {
                string envConfigContent = File.ReadAllText(envConfigFile);
                Environment.SetEnvironmentVariable("APP_SPECIFIC_VAR", envConfigContent, EnvironmentVariableTarget.Process);
            }
            else
            {
                Environment.SetEnvironmentVariable("APP_SPECIFIC_VAR", "File not found: " + envConfigFile, EnvironmentVariableTarget.Process);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}