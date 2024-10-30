using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ListFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
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
        string Query = "select * from tabFiles where Storage='" + security.Encrypt(drpCloudStorage.Text, Session["EncKey"].ToString()) + "'";
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
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        LoadFiles();
    }
}