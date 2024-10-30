using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for database
/// </summary>
public class db
{
    public static string projtitle = "Privacy Preserved Cloud Server";

    public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
    
    public static string GenerateContent(int ContentLength)
    {
        string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string Content = "";
        Random r = new Random();

        for (int i = 0; i <= ContentLength - 1; i++)
        {
            Content += charset[r.Next(0, charset.Length)];
        }

        return Content;
    }

    public static void OpenConnection()
    {
        if (con.State.ToString() == "Closed")
            con.Open();
    }

    public static Boolean CheckUser()
    {
        Boolean Answer = false;
        if (HttpContext.Current.Session["UserType"] == "User")
        {
            Answer = true;
        }
        return Answer;
    }

    public static Boolean CheckAdmin()
    {
        Boolean Answer = false;
        if (HttpContext.Current.Session["UserType"] == "Admin")
        {
            Answer = true;
        }
        return Answer;
    }

    public static void LoadDropDownList(string Query, DropDownList drpDropdownList, Label lblNotification)
    {
        try
        {
            drpDropdownList.Items.Clear();

            OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    drpDropdownList.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    public static Boolean CheckRecord(string Query, Label lblNotification)
    {
        Boolean answer = false;
        try
        {
            lblNotification.Text = "";

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
                answer = true;

            dr.Close();
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
        return answer;
    }


    public static Boolean CheckRecord(string Query)
    {
        Boolean answer = false;
        try
        {

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
                answer = true;

            dr.Close();
        }
        catch
        {
            //do nothing
        }
        finally
        {
            con.Close();
        }
        return answer;
    }

    public static string LoadText(string Query, Label lblNotification)
    {
        string answer = "";
        try
        {
            lblNotification.Text = "";

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
                answer = dr[0].ToString();

            dr.Close();
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
        return answer;
    }

    public static int LoadValue(string Query, Label lblNotification)
    {
        int answer = 0;
        try
        {
            lblNotification.Text = "";

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
                answer = Convert.ToInt32(dr[0].ToString());

            dr.Close();
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
        return answer;
    }

    public static string LoadText(string Query)
    {
        string answer = "";
        try
        {

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
                answer = dr[0].ToString();

            dr.Close();
        }
        catch
        {
            //do nothing
        }
        finally
        {
            con.Close();
        }
        return answer;
    }

    public static int ExecNonQuery(string Query)
    {
        int Answer = 0;
        try
        {

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                Answer = 1;
        }
        catch (Exception ex)
        {
            //donothing
        }
        finally
        {
            con.Close();
        }
        return Answer;
    }


    public static int ExecNonQuery(string Query, Label lblNotification, string NotificationMessage)
    {
        int Answer = 0;
        try
        {
            lblNotification.Text = "";

            OpenConnection();

            SqlCommand cmd = new SqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
                lblNotification.Text = NotificationMessage.ToString();

            Answer = i;
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
        return Answer;
    }

    public static void LoadGridView(string Query, GridView gvGridView, Label lblNotification)
    {
        try
        {
            gvGridView.DataSource = null;
            gvGridView.DataBind();

            OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvGridView.DataSource = ds.Tables[0];
                gvGridView.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    public static void LoadDataList(string Query, DataList dlDataList, Label lblNotification)
    {
        try
        {
            dlDataList.DataSource = null;
            dlDataList.DataBind();

            OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dlDataList.DataSource = ds.Tables[0];
                dlDataList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblNotification.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
    }
}