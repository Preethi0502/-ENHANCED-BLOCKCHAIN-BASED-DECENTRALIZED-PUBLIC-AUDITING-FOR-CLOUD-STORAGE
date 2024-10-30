using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserDetails : System.Web.UI.Page
{

    static string UserID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnUpload.UniqueID;
            updatePanel.Triggers.Add(trigger);

            if (db.CheckUser() == true)
            {
                LoadDetailsEncryptedPart();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    void LoadDetailsEncryptedPart()
    {
        try
        {
            UserID = Session["UserID"].ToString();
            lblUserName.Text = db.LoadText("select substring(UName,1,15) from tabUsers where UserID='" + UserID + "'");
            lblGender.Text = db.LoadText("select substring(Gender,1,15) from tabUsers where UserID='" + UserID + "'");
            lblBirthDate.Text = db.LoadText("select substring(BirthDate,1,15) from tabUsers where UserID='" + UserID + "'");
            lblMobileNumber.Text = db.LoadText("select substring(MobileNumber,1,15) from tabUsers where UserID='" + UserID + "'");
            lblEmailID.Text = db.LoadText("select substring(EmailID,1,15) from tabUsers where UserID='" + UserID + "'");
            lblUserID.Text = UserID.Substring(0,16);
        }
        catch
        {
            Response.Redirect("~/UserDashboard.aspx", false);
        }
    }

    string EncKey;
    protected void btnUpload_Click(object sender, EventArgs e)
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


            UserID = Session["UserID"].ToString();

            string UName = db.LoadText("select UName from tabUsers where UserID='" + UserID + "'");
            string Gender = db.LoadText("select Gender from tabUsers where UserID='" + UserID + "'");
            string BirthDate = db.LoadText("select BirthDate from tabUsers where UserID='" + UserID + "'");
            string MobileNumber = db.LoadText("select MobileNumber from tabUsers where UserID='" + UserID + "'");
            string EmailID = db.LoadText("select EmailID from tabUsers where UserID='" + UserID + "'");
            

            lblUserID.Text = security.Decrypt(UserID, EncKey);
            lblUserName.Text = security.Decrypt(UName, EncKey);
            lblGender.Text = security.Decrypt(Gender, EncKey);
            lblBirthDate.Text = security.Decrypt(BirthDate, EncKey);
            lblMobileNumber.Text = security.Decrypt(MobileNumber, EncKey);
            lblEmailID.Text = security.Decrypt(EmailID, EncKey);
        }
        catch
        {
            Response.Redirect("~/UserDetailsInvalidKey.aspx");
        }
    }
}