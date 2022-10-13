using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student_DAL
    {
        public bool Insert(marks school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into marks(student_id,student_name,subject_marks) values(@student_id,@student_name,@subject_marks)", cn);
            cmdInsert.Parameters.AddWithValue("@student_id", school.student_id);
            cmdInsert.Parameters.AddWithValue("@student_name", school.student_name);
            cmdInsert.Parameters.AddWithValue("@subject_marks", school.subject_marks);




            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }
        public bool Update(marks school)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatemarks]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_studid", school.student_id);
            cmdUpdate.Parameters.AddWithValue("@p_studname", school.student_name);
            cmdUpdate.Parameters.AddWithValue("@p_submarks", school.subject_marks);
            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }

        public marks Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");


            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findmarks", cn);

            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_studid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_mark_studname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 30;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_marks_submarks";
            p2.SqlDbType = System.Data.SqlDbType.Int;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);





            cn.Open();
            cmdSelect.ExecuteNonQuery();

            marks found = new marks();

            found.student_name = p1.Value.ToString();
            found.subject_marks = Convert.ToInt32(p2.Value);





            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<marks> List()
        {


            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdlist = new SqlCommand("select student_id,student_name,subject_marks from marks", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<marks> emplist = new List<marks>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    marks bal = new marks();
                    bal.student_id = Convert.ToInt32(dr["student_id"]);
                    bal.student_name = dr["student_name"].ToString();
                    bal.subject_marks = Convert.ToInt32(dr["subject_marks"]);


                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Delete(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=School;Integrated Security=True");

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletemarks", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }




    }
}
