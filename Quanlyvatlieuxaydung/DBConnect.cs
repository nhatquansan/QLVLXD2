﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quanlyvatlieuxaydung
{
    class DBConnect
    {
        SqlConnection connect;

        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        string strConnect = @"Data Source = AcerNitro5\NHATQUAN ; Initial Catalog = QuanLy_VLXD5; User ID = sa; Password = 123";

        public DBConnect()
        {
            connect = new SqlConnection(strConnect);
        }

        public void open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Close();
        }

        public int getNonQuery(string strsql)
        {
            open();
            SqlCommand cmd = new SqlCommand(strsql, connect);
            int kq = cmd.ExecuteNonQuery();
            close();
            return kq;
        }
        public SqlDataReader getDataReader(string strsql)
        {
            open();
            SqlCommand cmd = new SqlCommand(strsql, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public object getScalar(string strsql)
        {
            open();
            SqlCommand cmd = new SqlCommand(strsql, connect);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }

        public DataTable getDataTable(string strsql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strsql, connect);
            da.Fill(dt);
            return dt;
        }

        public int updateDataBase(string sql, DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            SqlCommandBuilder cB = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }
        

    }
}