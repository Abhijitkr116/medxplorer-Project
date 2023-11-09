using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class DoctorInsertManager
    {
        String src = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
        int count;
        public int InsertData(DoctorInsertModel doctorinsertModel)
        {
            using (SqlConnection conn = new SqlConnection(src))
            {
                using (SqlCommand cmd = new SqlCommand("prc_insertData", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@Doctor_Name", doctorinsertModel.Doctor_Name);
                        cmd.Parameters.AddWithValue("@Specialist", doctorinsertModel.Specialist);
                        cmd.Parameters.AddWithValue("@State", doctorinsertModel.State);
                        cmd.Parameters.AddWithValue("@city", doctorinsertModel.city);
                        cmd.Parameters.AddWithValue("@Full_Address", doctorinsertModel.Full_Address);
                        cmd.Parameters.AddWithValue("@Experience ", doctorinsertModel.Experience);
                        cmd.Parameters.AddWithValue("@Working_Place", doctorinsertModel.Working_Place);
                        cmd.Parameters.AddWithValue("@Start_Time", doctorinsertModel.Start_Time);
                        cmd.Parameters.AddWithValue("@End_Time", doctorinsertModel.End_Time);
                        cmd.Parameters.AddWithValue("@Qualification", doctorinsertModel.Qualification);
                        cmd.Parameters.AddWithValue("@Contact_No", doctorinsertModel.Contact_No);
                        cmd.Parameters.AddWithValue("@Fees", doctorinsertModel.Fees);

                        conn.Open();
                        count = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        var Error = ex.Message;
                    }
                    finally
                    {
                        if (conn.State != System.Data.ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }

                }
                return count;
            }
        }
    }
}