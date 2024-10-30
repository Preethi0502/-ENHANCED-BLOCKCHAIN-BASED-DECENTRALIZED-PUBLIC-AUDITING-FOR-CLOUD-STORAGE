using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class ListFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (db.CheckUser() == true)
            {
                UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
                UpdatePanelControlTrigger trigger = new PostBackTrigger();
                trigger.ControlID = btnOpenShare.UniqueID;
                updatePanel.Triggers.Add(trigger);

                UpdatePanelControlTrigger triggerupload = new PostBackTrigger();
                triggerupload.ControlID = btnUpload.UniqueID;
                updatePanel.Triggers.Add(triggerupload);

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        else
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger triggerupload = new PostBackTrigger();
            triggerupload.ControlID = btnUpload.UniqueID;
            updatePanel.Triggers.Add(triggerupload);
        }
    }

    void LoadFiles(string StorageName)
    {
        string Query = "select * from tabFiles where Storage='" + StorageName + "'";
        db.LoadGridView(Query, dgvFiles, lblNotification);
    }

    protected void dgvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Download"))
        {
            int i = Convert.ToInt32(e.CommandArgument);
            string FileID = dgvFiles.DataKeys[i].Value.ToString();
            Response.Redirect("~/Download.aspx?FileID=" + FileID);
        }
    }

    private static string UploadStorageName = "";
    private static string UploadKey = "";
    private static string UploadPermission = "";
    protected void btnOpenShare_Click(object sender, EventArgs e)
    {
        try
        {
            string textLine = "";
            if (fuKeyFile.HasFile)
            {
                StreamReader reader = new StreamReader(fuKeyFile.FileContent);
                do
                {
                    textLine = reader.ReadLine();
                }
                while (reader.Peek() != -1);
                reader.Close();
            }


            string dd = textLine;
            string[] separators = { "." };
            string value = dd.ToString();
            string[] words = value.Split(separators, StringSplitOptions.None);

            string Permission = words[0].ToString();
            string StorageName = words[1].ToString();
            string EncKey = words[2].ToString();

            UploadStorageName = StorageName;
            UploadKey = EncKey;
            UploadPermission = Permission;

            lblStorageName.Text = security.Decrypt(StorageName, EncKey);
            
            LoadFiles(StorageName);
            if (Permission == "R")
            {
                dgvFiles.Columns[3].Visible = true;
                lblPermission.Text = "Permission : Read";
            }
            if (Permission == "W")
            {
                dgvFiles.Columns[3].Visible = true;
                lblPermission.Text = "Permission : Read & Write";
            }
        }
        catch
        {
            Response.Redirect("~/OpenShareError.aspx");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (UploadPermission == "W")
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
                    SqlCommand cmd = new SqlCommand("insert into tabFiles values('" + fname + "','" + fuFile.FileName + "','" + UploadStorageName + "','" + FormatFileSize(fuFile.PostedFile.ContentLength) + "','" + Session["UserID"] + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "')", db.con);
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
        else
        {
            lblNotification.Text = "Permission denied.";
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