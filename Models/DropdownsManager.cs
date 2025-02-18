using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class DropdownsManager
    {
        String sc = ConfigurationManager.ConnectionStrings["project"].ConnectionString;

        public DoctorInsertModel GetSpecialists(DoctorInsertModel SpecialistsModel)
        {
            using(SqlConnection cn = new SqlConnection(sc))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetSpecialists", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            SpecialistsModel.ListofSpecialist.Add(Convert.ToString(dr["Specialist"]));
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return SpecialistsModel;
                }
            }
        }

        public DoctorInsertModel GetState(DoctorInsertModel State)
        {
            using(SqlConnection cn = new SqlConnection(sc))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetState", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            State.ListofState.Add(Convert.ToString(dr["StateName"]));
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return State;
                }
            }
        }

        public DoctorInsertModel GetCity(String state)
        {
            DoctorInsertModel City = new DoctorInsertModel();
            using(SqlConnection cn = new SqlConnection(sc))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetCity", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@statename", state);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            City.ListofCity.Add(Convert.ToString(dr["CityName"]));
                        }
                        dr.Close();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return City;
                }
            }
        }

        public DoctorInsertModel GetDoctorsName(DoctorInsertModel doctors)
        {
            using( SqlConnection cn = new SqlConnection(sc))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetDoctors", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            doctors.ListofDoctors.Add(Convert.ToString(dr["Doctor_Name"]));
                        }
                        dr.Close();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return doctors;
                }
            }
        }
    }
}