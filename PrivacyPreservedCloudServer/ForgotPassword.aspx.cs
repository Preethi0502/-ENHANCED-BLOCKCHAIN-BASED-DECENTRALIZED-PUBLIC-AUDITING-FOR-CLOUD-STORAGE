using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;


public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnGetPassword.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
    }

    public static string EncKey;
    protected void btnGetPassword_Click(object sender, EventArgs e)
    {
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

            string Query = "select Password from tabUsers where UserID='" + UserID + "'";
            if (db.CheckRecord(Query) == true)
            {
                Session["EncKey"] = EncKey;

                Query = "select Password from tabUsers where UserID='" + UserID + "'";
                string Password = security.Decrypt(db.LoadText(Query), EncKey);
                lblNotification.Text = "Your Password is " + Password;
                lblNotification.ForeColor = System.Drawing.Color.Green;
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