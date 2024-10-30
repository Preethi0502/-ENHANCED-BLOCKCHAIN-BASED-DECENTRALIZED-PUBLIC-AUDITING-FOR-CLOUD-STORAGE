using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserID"].ToString() == "")
        {
            lblUser.Text = "Guest";
            lbtLogout.Visible = false;
        }
        else
        {
            if (Session["UserID"] == "admin")
            {
                lblUser.Text = "Administrator";
            }
            else
            {
                lblUser.Text = Session["UserName"].ToString();
                lbtLogout.Visible = true;

            }
        }
    }
    protected void lbtLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        Session["UserType"] = "";
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
