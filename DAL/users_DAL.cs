using CRUD_for_signup_using_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CRUD_for_signup_using_MVC.DAL
{
    public class users_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["mvcConnectionstring"].ToString();


        //get all users

        public List<User>GetAllUsers()
        {
            List<User> usersList = new List<User>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPS_userDetails";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUser = new DataTable();

                con.Open();
                sqlDA.Fill(dtUser);
                con.Close();


                foreach (DataRow dr in dtUser.Rows)
                {
                    usersList.Add(new User
                    {
                        id = Convert.ToInt32(dr["id"]),
                        first_name = dr["first_name"].ToString(),
                        last_name = dr["last_name"].ToString(),
                        date_of_birth = Convert.ToDateTime(dr["date_of_birth"]),
                        gender = dr["gender"].ToString(),
                        phone_number = dr["phone_number"].ToString(),
                        email_address = dr["email_address"].ToString(),
                        address = dr["address"].ToString(),
                        state = dr["state"].ToString(),
                        city = dr["city"].ToString(),
                        username = dr["username"].ToString(),
                        password = dr["password"].ToString(),
                        profile_photo = dr["profile_photo"].ToString()


                    });
                }
            }
            
            return usersList;
        }

        //insert user details
        public bool InsertUserDetails(User user,HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            int id = 0;
            using(SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SPI_userDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", user.first_name);
                cmd.Parameters.AddWithValue("@last_name", user.last_name);
                cmd.Parameters.AddWithValue("@date_of_birth", user.date_of_birth);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@phone_number", user.phone_number);
                cmd.Parameters.AddWithValue("@email_address", user.email_address);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@state", user.state);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                if(file != null && file.ContentLength>0) 
                { 
                    string filename = Path.GetFileName(file.FileName);
                    string imagepath = Path.Combine(server.MapPath("~/User_images/"), filename);
                    file.SaveAs(imagepath);
                }
                cmd.Parameters.AddWithValue("@profile_photo", "~/User_images/" + file.FileName);



                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (id > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
       
        
        }


        //get  users details by id

        public List<User> GetUsersDetailsById(int id)
        {
            List<User> usersList = new List<User>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPS_userDetailsById";
                cmd.Parameters.AddWithValue ("@id", id);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUser = new DataTable();

                con.Open();
                sqlDA.Fill(dtUser);
                con.Close();


                foreach (DataRow dr in dtUser.Rows)
                {
                    usersList.Add(new User
                    {
                        id = Convert.ToInt32(dr["id"]),
                        first_name = dr["first_name"].ToString(),
                        last_name = dr["last_name"].ToString(),
                        date_of_birth = Convert.ToDateTime(dr["date_of_birth"]),
                        gender = dr["gender"].ToString(),
                        phone_number = dr["phone_number"].ToString(),
                        email_address = dr["email_address"].ToString(),
                        address = dr["address"].ToString(),
                        state = dr["state"].ToString(),
                        city = dr["city"].ToString(),
                        username = dr["username"].ToString(),
                        password = dr["password"].ToString(),
                        profile_photo = dr["profile_photo"].ToString()


                    });
                }
            }

            return usersList;
        }


        //update user details
        public bool UpdateUserDetails(User user, HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SPU_userDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@first_name", user.first_name);
                cmd.Parameters.AddWithValue("@last_name", user.last_name);
                cmd.Parameters.AddWithValue("@date_of_birth", user.date_of_birth);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@phone_number", user.phone_number);
                cmd.Parameters.AddWithValue("@email_address", user.email_address);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@state", user.state);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string imagepath = Path.Combine(server.MapPath("~/User_images/"), filename);
                    file.SaveAs(imagepath);
                }
                cmd.Parameters.AddWithValue("@profile_photo", "~/User_images/" + file.FileName);



                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}