using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnLogin.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
    }

    public static string EncKey;
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["EncKey"] = "";
        try
        {
            if (fuKeyFile.HasFile)
            {
                StreamReader reader = new StreamReader(fuKeyFile.FileContent);
                do
                {
                    string textLine = reader.ReadLine();
                    EncKey = textLine;
                }
                while (reader.Peek() != -1);
                reader.Close();
            }

            string UserID = security.Encrypt(txtUserID.Text, EncKey);
            string Password = security.Encrypt(txtPassword.Text, EncKey);

            string Query = "select * from tabUsers where UserID='" + UserID + "' and Password='" + Password + "'";
            if (db.CheckRecord(Query) == true)
            {
                Session["EncKey"] = EncKey;

                Query = "select UName from tabUsers where UserID='" + UserID + "'";
                string UserName = security.Decrypt(db.LoadText(Query), EncKey);
                Session["UserID"] = UserID;
                Session["UserName"] = UserName;
                Session["UserType"] = "User";
                Response.Redirect("~/UserDashboard.aspx");

            }
            else
            {
                Response.Redirect("~/LoginFailed.aspx");
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
    }
}