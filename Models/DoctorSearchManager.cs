using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class DoctorSearchManager
    {
        String sc = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
public List<DoctorInsertModel> Search_Data(DoctorInsertModel insertModel)
{
    List<DoctorInsertModel> insertModel1 = new List<DoctorInsertModel>();
    String str = Convert.ToString(insertModel.Specialist);
    String str1 = Convert.ToString(insertModel.Doctor_Name);
    string str2 = Convert.ToString(insertModel.city);
    using (SqlConnection conn = new SqlConnection(sc))
    {
        if (str != null && str2 != null && str1 == null)
        {
            using (SqlCommand cmd = new SqlCommand("prc_searchData1", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.AddWithValue("@Specialist", insertModel.Specialist);
                    cmd.Parameters.AddWithValue("@city ", insertModel.city);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DoctorInsertModel m = new DoctorInsertModel();
                        m.Doctor_Name = Convert.ToString(dr["Doctor_Name"]);
                        m.Specialist = Convert.ToString(dr["Specialist"]);
                        m.State = Convert.ToString(dr["State"]);
                        m.city = Convert.ToString(dr["city"]);
                        m.Full_Address = Convert.ToString(dr["Full_Address"]);
                        m.Experience = Convert.ToString(dr["Experience"]);
                        m.Working_Place = Convert.ToString(dr["Working_Place"]);
                        m.Start_Time = Convert.ToString(dr["Start_Time"]);
                        m.End_Time = Convert.ToString(dr["End_Time"]);
                        m.Qualification = Convert.ToString(dr["Qualification"]);
                        m.Contact_No = Convert.ToString(dr["Contact_No"]);
                        m.Fees = Convert.ToInt32(dr["Fees"]);
                        insertModel1.Add(m);
                    }
                }
                catch (Exception ex)
                {
                    var er = ex.Message;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
        else if (str1 != null && str2 != null && str == null)
        {
            using (SqlCommand cmd = new SqlCommand("prc_searchData2", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    //cmd.Parameters.AddWithValue("@Specialist", insertModel.Specialist);
                    cmd.Parameters.AddWithValue("@Doctor_Name", insertModel.Doctor_Name);
                    cmd.Parameters.AddWithValue("@city ", insertModel.city);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                                DoctorInsertModel m1 = new DoctorInsertModel();
                        m1.Doctor_Name = Convert.ToString(dr["Doctor_Name"]);
                        m1.Specialist = Convert.ToString(dr["Specialist"]);
                        m1.State = Convert.ToString(dr["State"]);
                        m1.city = Convert.ToString(dr["city"]);
                        m1.Full_Address = Convert.ToString(dr["Full_Address"]);
                        m1.Experience = Convert.ToString(dr["Experience"]);
                        m1.Working_Place = Convert.ToString(dr["Working_Place"]);
                        m1.Start_Time = Convert.ToString(dr["Start_Time"]);
                        m1.End_Time = Convert.ToString(dr["End_Time"]);
                        m1.Qualification = Convert.ToString(dr["Qualification"]);
                        m1.Contact_No = Convert.ToString(dr["Contact_No"]);
                        m1.Fees = Convert.ToInt32(dr["Fees"]);
                        insertModel1.Add(m1);
                    }
                }
                catch (Exception ex)
                {
                    var er = ex.Message;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
        else if (str != null && str1 != null && str2 != null)
        {
            using (SqlCommand cmd = new SqlCommand("prc_searchData", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.AddWithValue("@Specialist", insertModel.Specialist);
                    cmd.Parameters.AddWithValue("@Doctor_Name", insertModel.Doctor_Name);
                    cmd.Parameters.AddWithValue("@city ", insertModel.city);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                                DoctorInsertModel m2 = new DoctorInsertModel();
                        m2.Doctor_Name = Convert.ToString(dr["Doctor_Name"]);
                        m2.Specialist = Convert.ToString(dr["Specialist"]);
                        m2.State = Convert.ToString(dr["State"]);
                        m2.city = Convert.ToString(dr["city"]);
                        m2.Full_Address = Convert.ToString(dr["Full_Address"]);
                        m2.Experience = Convert.ToString(dr["Experience"]);
                        m2.Working_Place = Convert.ToString(dr["Working_Place"]);
                        m2.Start_Time = Convert.ToString(dr["Start_Time"]);
                        m2.End_Time = Convert.ToString(dr["End_Time"]);
                        m2.Qualification = Convert.ToString(dr["Qualification"]);
                        m2.Contact_No = Convert.ToString(dr["Contact_No"]);
                        m2.Fees = Convert.ToInt32(dr["Fees"]);
                        insertModel1.Add(m2);
                    }
                }
                catch (Exception ex)
                {
                    var er = ex.Message;
                }
                finally
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
        return insertModel1;
    }
}
}
}