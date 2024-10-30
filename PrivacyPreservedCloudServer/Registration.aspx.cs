using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnRegister.UniqueID;
            updatePanel.Triggers.Add(trigger);

            EncKey = db.GenerateContent(8);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }

    int SaveFile(string EncKey)
    {
        int Answer = 0;
        try
        {
            string text = EncKey;
            string attachment = String.Format("attachment; filename=" + txtUserID.Text + ".txt");
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.Write(text);
            Answer = 1;
            HttpContext.Current.Response.End();
            
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        return Answer;
    }

    private static string EncKey;
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        if (txtUserID.Text.Length > 3)
        {
            string Query = "select * from tabUsers where UserID='" + security.Encrypt( txtUserID.Text, EncKey) + "'";
            if (db.CheckRecord(Query) == false)
            {
                string UName = security.Encrypt(txtName.Text, EncKey);
                string Gender = security.Encrypt(drpGender.Text, EncKey);
                string BirthDate = security.Encrypt(txtBirthDate.Text, EncKey);
                string MobileNumber = security.Encrypt(txtMobileNumber.Text, EncKey);
                string EmailID = security.Encrypt(txtEmailID.Text, EncKey);
                string UserID = security.Encrypt(txtUserID.Text, EncKey);
                string Password = security.Encrypt(txtPassword1.Text, EncKey);

                Query = "insert into tabUsers values('" + UName + "','" + Gender + "','" + BirthDate + "','" + MobileNumber + "','" + EmailID + "','" + UserID + "','" + Password + "')";
                int i = db.ExecNonQuery(Query);
                lblNotification.Text = "Registration Successfull";
                if (i > 0)
                {
                    i = 0;
                    i = SaveFile(EncKey);
                }

                if (i > 0)
                    Response.Redirect("~/RegistrationSuccess.aspx");
                
            }
            else
            {
                lblNotification.Text = "User account already exists!";
            }
        }
        else
        {
            lblNotification.Text = "User ID is too short";
        }
    }
}