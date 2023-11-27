using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace electronic_products_project
{
    public class Connectioncls
    {
        SqlConnection con;
        SqlCommand cmd;
        public Connectioncls()
        {
            con = new SqlConnection(@"server=LAPTOP-7EURCCIK\SQLEXPRESS;database=Electronic_project;integrated security=true");
        }





        public int Fn_Nonquery(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }




        public string Fn_scalar(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }





        //public SqlDataReader Fn_reader(string sqlquery)
        //{
        //    if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //    cmd = new SqlCommand(sqlquery, con);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //}





        public DataSet fn_dataSet(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }





        //public DataTable Fn_Datatable(String sqlquery)
        //{
        //    if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
    }
}