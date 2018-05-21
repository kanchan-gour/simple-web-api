using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestwebApiapp.Models
{
    public class CrudDataService
    {
        public List<tblCustomer> GetCustomerList(int PageNo, int RowCountPerPage, int IsPaging)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<tblCustomer> _listCustomer = new List<tblCustomer>();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("READ_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNo", PageNo);
                objCommand.Parameters.AddWithValue("@RowCountPerPage", RowCountPerPage);
                objCommand.Parameters.AddWithValue("@IsPaging", IsPaging);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    tblCustomer objCust = new tblCustomer();
                    objCust.FirstName = Convert.ToString(_Reader["FirstName"]);
                    objCust.LastName = _Reader["LastName"].ToString();
                    objCust.Email = _Reader["Email"].ToString();
                    objCust.PhoneNumber = _Reader["PhoneNumber"].ToString();
                    objCust.Status = _Reader["Status"].ToString();
                    _listCustomer.Add(objCust);
                }

                return _listCustomer;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public tblCustomer GetCustomerDetails(string FName)
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                tblCustomer objCust = new tblCustomer();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
                FName = FName.Replace("\"", string.Empty).Trim();

                string comtext = "select * from tblCustomer where FirstName=" + "'" + FName + "'";
                SqlCommand objCommand = new SqlCommand(comtext, Conn);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    objCust.FirstName = Convert.ToString(_Reader["FirstName"]);
                    objCust.LastName = _Reader["LastName"].ToString();
                    objCust.Email = _Reader["Email"].ToString();
                    objCust.PhoneNumber = _Reader["PhoneNumber"].ToString();
                    objCust.Status = _Reader["Status"].ToString();
                }

                return objCust;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 InsertCustomer(tblCustomer objCust)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("CREATE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FirstName", objCust.LastName);
                objCommand.Parameters.AddWithValue("@LastName", objCust.LastName);
                objCommand.Parameters.AddWithValue("@Email", objCust.Email);
                objCommand.Parameters.AddWithValue("@PhoneNumber", objCust.PhoneNumber);
                objCommand.Parameters.AddWithValue("@Status", objCust.Status);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 UpdateCustomer(tblCustomer objCust)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("UPDATE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FirstName", objCust.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", objCust.LastName);
                objCommand.Parameters.AddWithValue("@Email", objCust.Email);
                objCommand.Parameters.AddWithValue("@PhoneNumber", objCust.PhoneNumber);
                objCommand.Parameters.AddWithValue("@Status", objCust.Status);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 DeleteCustomer(string Fname)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("DELETE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@FirstName", Fname);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }
    }
}