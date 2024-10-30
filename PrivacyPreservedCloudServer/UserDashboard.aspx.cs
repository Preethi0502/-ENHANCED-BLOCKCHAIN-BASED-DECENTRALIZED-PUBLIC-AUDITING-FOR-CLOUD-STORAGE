using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (db.CheckUser() == true)
            {
                string Query = "select * from tabUserMenu order by 1";
                db.LoadDataList(Query, dlMenu, lblNotification);
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void dlMenu_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "OpenLink")
        {
            string MenuID = dlMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].ToString();
            string NavURL = db.LoadText("select NavURL from tabUserMenu where MenuID='" + MenuID.ToString() + "'");
            Response.Redirect(NavURL);
        }
    }
}