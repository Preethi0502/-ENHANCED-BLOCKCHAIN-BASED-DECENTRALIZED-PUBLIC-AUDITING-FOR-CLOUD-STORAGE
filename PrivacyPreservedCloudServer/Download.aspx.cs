using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Download : System.Web.UI.Page
{

    private static string FileID;
    private static string FilePassword;
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
        UpdatePanelControlTrigger trigger = new PostBackTrigger();
        trigger.ControlID = btnDownload.UniqueID;
        updatePanel.Triggers.Add(trigger);

        if (IsPostBack == false)
        {

            if (db.CheckUser() == true)
            {
                try
                {
                    FileID = Request.QueryString["FileID"].ToString();
                    lblFileName.Text = db.LoadText("select FileName from tabFiles where FileID='" + FileID + "'");
                    lblFileSize.Text = db.LoadText("select FileSize from tabFiles where FileID='" + FileID + "'");
                    lblOwnerName.Text = db.LoadText("select Owner from tabFiles where FileID='" + FileID + "'");
                    lblUploadedDate.Text = db.LoadText("select UploadOn from tabFiles where FileID='" + FileID + "'");

                }
                catch
                {
                    Response.Redirect("~/ListFiles.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    static string filepath;
    static string filename;
    static Boolean CheckPassword;
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        lblNotification.ForeColor = System.Drawing.Color.Red;
        lblNotification.Text = "";
        lblNotification.Text = "";
        filepath = "~/Files/" + FileID;
        FileInfo file = new FileInfo(Server.MapPath(filepath));
        filename = Server.MapPath(filepath);
        lblNotification.Text = filename;
        try
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblFileName.Text);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "text/plain";
            Response.TransmitFile(file.FullName);


            lblNotification.Text = "File Downloaded Successfully!";
            lblNotification.ForeColor = System.Drawing.Color.ForestGreen;
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
    }
}