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

public partial class AddCloudStorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (db.CheckUser() == true)
            {
                UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
                UpdatePanelControlTrigger trigger = new PostBackTrigger();
                trigger.ControlID = btnCreate.UniqueID;
                updatePanel.Triggers.Add(trigger);

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
        string Query = "select substring(StorageName,1,8) as StorageName from tabStorage where UserID='" + Session["UserID"].ToString() + "'";
        db.LoadDataList(Query, dlStorage, lblNotification);
    }

    void AlterStorageNames()
    {
        try
        {
            if (dlStorage.Items.Count > 0)
            {
                string StorageName;
                foreach (DataListItem item in dlStorage.Items)
                {
                    StorageName = ((Label)(item.FindControl("lblStorageName"))).Text;

                }
            }
        }
        catch (Exception ex)
        {
            lblNotification0.Text = ex.Message.ToString();
        }
    }


    private DataTable GetData(string EncKey)
    {
        lblNotification.Text = "";
        DataTable dt = new DataTable();
        try
        {
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("StorageName", typeof(String)));

            db.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("select StorageName from tabStorage where UserID='" + Session["UserID"].ToString() + "'", db.con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = security.Decrypt(ds.Tables[0].Rows[i].ItemArray[0].ToString(), EncKey);
                    dt.Rows.Add(dr);
                }
            }
        }
        catch
        {
            Response.Redirect("~/AddCloudStorageInvalidKey.aspx");
        }
        return dt;
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            string StorageName = security.Encrypt(txtUserID.Text, Session["EncKey"].ToString());
            string Query = "select * from tabStorage where StorageName='" + StorageName + "'";

            if (db.CheckRecord(Query) == false)
            {
                Query = "insert into tabStorage values('" + StorageName + "','" + Session["UserID"].ToString() + "')";
                int i = db.ExecNonQuery(Query);

                if (i > 0)
                {
                    lblNotification.Text = "Storage Added Successfully!";
                    LoadStorage();
                }
            }
            else
            {
                lblNotification.Text = "Storage Name already exists!";
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string EncKey;
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

                DataTable dt = GetData(EncKey);
                dlStorage.DataSource = dt;
                dlStorage.DataBind();
            }
        }
        catch
        {
            Response.Redirect("~/AddCloudStorageInvalidKey.aspx");
        }
    }
}