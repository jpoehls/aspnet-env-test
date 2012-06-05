using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnvTestApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Controls.Add(new LiteralControl("APP_SPECIFIC_VAR: <b>" + Environment.GetEnvironmentVariable("APP_SPECIFIC_VAR", EnvironmentVariableTarget.Process) + "</b>"));
        }
    }
}