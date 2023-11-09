using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class LoginManager
    {
            string scn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            public SignupModel UserAuth(SignupModel loginModel)
            {
                using (SqlConnection cn = new SqlConnection(scn))
                {
                    using (SqlCommand cmd = new SqlCommand("prc_validatedata", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@useremail", System.Data.SqlDbType.VarChar, 100).Value = loginModel.email;// email from user
                        cmd.Parameters.Add("@userpass", System.Data.SqlDbType.Int).Value = loginModel.password;//password from user
                        try
                        {
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr["Email"] != DBNull.Value && dr["Role"] != DBNull.Value)//for pick their name and role 
                                {
                                    loginModel.email = Convert.ToString(dr["Email"]);//convert to string                              loginModel.Name = Convert.ToString(dr["Name"]);//convert to string  
                                    loginModel.Role = Convert.ToString(dr["Role"]);
                                    loginModel.Isvalid = 1; // means user is valid {true}
                                }
                                else
                                {
                                    loginModel.Isvalid = 0; // means user isn't valid {false}
                                }
                            }
                            dr.Close(); ; // closes the read method

                        }
                        catch (Exception ex)
                        {
                            string exc = ex.Message;
                        }
                        finally
                        {
                            if (cn.State == System.Data.ConnectionState.Open)//if connection is open then close it
                            {
                                cn.Close();//cosed connection
                            }
                        }
                        return loginModel;  // here we return the values from database

                    }
                }
            }

        
    }
    
}