using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class UploadFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (db.CheckUser() == true)
            {
                UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
                UpdatePanelControlTrigger triggerupload = new PostBackTrigger();
                triggerupload.ControlID = btnUpload.UniqueID;
                updatePanel.Triggers.Add(triggerupload);


                LoadStorage();
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
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string PostedFile = fuFile.FileName;

        lblNotification.Text = PostedFile;
        string allowedChars = "";
        allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
        allowedChars += "1,2,3,4,5,6,7,8,9,0";

        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);

        string fname = "";

        string temp = "";

        Random rand = new Random();
        for (int i = 0; i < 20; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            fname += temp;
        }

        if (fuFile.HasFile)
        {
            try
            {
                fuFile.PostedFile.SaveAs(MapPath("~/Files/" + fname));
                string FileName = fuFile.FileName;
                db.con.Open();
                SqlCommand cmd = new SqlCommand("insert into tabFiles values('" + fname + "','" + fuFile.FileName + "','" + security.Encrypt(drpCloudStorage.Text, Session["EncKey"].ToString()) + "','" + FormatFileSize(fuFile.PostedFile.ContentLength) + "','" + Session["UserID"] + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "')", db.con);
                cmd.ExecuteNonQuery();
                lblNotification.ForeColor = System.Drawing.Color.Green;
                lblNotification.Text += " Uploaded";
                db.con.Close();
            }
            catch (Exception ex)
            {
                lblNotification.ForeColor = System.Drawing.Color.Red;
                lblNotification.Text = ex.Message.ToString();
                db.con.Close();
            }
        }
    }

    private string FormatFileSize(long bytes)
    {
        if (bytes > 1099511627776)
        {
            return ((float)bytes / 1099511627776).ToString("0.00 TB");
        }
        else if (bytes > 1073741824)
        {
            return ((float)bytes / 1073741824).ToString("0.00 GB");
        }
        else if (bytes > 1048576)
        {
            return ((float)bytes / 1048576).ToString("0.00 MB");
        }
        else if (bytes > 1024)
        {
            return ((float)bytes / 1024).ToString("0.00 KB");
        }
        else return bytes + " Bytes";
    }
}