using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;

namespace testProjek.View
{
    public partial class homeCustomer : System.Web.UI.Page
    {
        userController Controller = new userController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller.RedirectIfNotAuthenticated(Session, Request, Response);
        }
    }
}