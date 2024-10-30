using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ShareStorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {

            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnShare.UniqueID;
            updatePanel.Triggers.Add(trigger);

            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnWriteShare.UniqueID;
            updatePanel.Triggers.Add(trigger2);

            if (db.CheckUser() == true)
            {


                LoadStorage();
                LoadFiles();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    void LoadStorage()
    {
        drpCloudStorage.Items.Clear();
        try
        {
            db.OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter("select StorageName from tabStorage where UserID='" + Session["UserID"].ToString() + "'", db.con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string StorageName;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    StorageName = security.Decrypt(ds.Tables[0].Rows[i].ItemArray[0].ToString(), Session["EncKey"].ToString());
                    drpCloudStorage.Items.Add(StorageName);
                }
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            db.con.Close();
        }
    }

    void LoadFiles()
    {
        string Query = "select * from tabFiles where Owner='" + Session["UserID"].ToString() + "' and Storage='" + security.Encrypt(drpCloudStorage.Text, Session["EncKey"].ToString()) + "'";
        db.LoadGridView(Query, dgvFiles, lblNotification);
    }

    int RSaveFile(string EncKey)
    {
        int Answer = 0;
        try
        {
            string FName = EncKey.Substring(0, 8);
            string text = "R." + security.Encrypt(drpCloudStorage.Text, Session["EncKey"].ToString()) + "." + Session["EncKey"].ToString();
            string attachment = String.Format("attachment; filename=R" + FName + ".txt");
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

    int WSaveFile(string EncKey)
    {
        int Answer = 0;
        try
        {
            string FName = EncKey.Substring(0, 8);
            string text = "W." + security.Encrypt(drpCloudStorage.Text, Session["EncKey"].ToString()) + "." + Session["EncKey"].ToString();
            string attachment = String.Format("attachment; filename=W" + FName + ".txt");
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

    protected void btnShare_Click(object sender, EventArgs e)
    {
        RSaveFile(Session["EncKey"].ToString());
    }
    protected void btnWriteShare_Click(object sender, EventArgs e)
    {
        WSaveFile(Session["EncKey"].ToString());
    }
}