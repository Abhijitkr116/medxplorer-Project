using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class SignupManager
    {
            public int InsertStudentData(SignupModel signupmodel1)
            {
            int count = 0;
                string scn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(scn))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SignUp", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.AddWithValue("@name", signupmodel1.name);
                            cmd.Parameters.AddWithValue("@email", signupmodel1.email);
                            cmd.Parameters.AddWithValue("@password", signupmodel1.password);

                            cn.Open();
                            count = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        finally
                        {
                            if (cn.State == System.Data.ConnectionState.Open)
                            {
                                cn.Close();
                            }
                        }
                    }
                }
                return count;
            }
        
    }
    
}
