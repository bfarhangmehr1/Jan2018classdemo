using AppSecurity.BLL;
using AppSecurity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    if (!User.IsInRole(SecurityRoles.Staff))
                    {
                        Response.Redirect("~/Account/Login.aspx");
                    }
                }
            }

        }

        protected void GetUserID_Click(object sender, EventArgs e)
        {
            //grap the username from security (User)
            string username = User.Identity.Name;
            UserDisplayName.Text = username;
            //obtain the employee informatin for this username
            MessageUserControl.TryRun(() =>
            //connect to the Application 
            ApplicationUserManager secmgr = new ApplicationUserManager(
                UserStored<ApplicationUser>(new ApplicationDbContext
                ()));
            EmployeeInfo info = secmgr.User_GetEmploye(username);
            EmployeeID.Text = info.EmployeeID.ToString();
            EmployeeName=
        });

    }
}