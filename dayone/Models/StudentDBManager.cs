using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace dayone.Models
{
    public class StudentDBManager
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentDBManager()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\upandrunning\dayone\dayone\App_Data\Database1.mdf;Integrated Security=True");
        }

        public void SaveStudent(Student s)
        {
            cmd = new SqlCommand("Insert Into Student(Rno,SName,Marks) Values(@Rno,@SName,@Marks)", conn);
            cmd.Parameters.AddWithValue("@Rno", s.Rno);
            cmd.Parameters.AddWithValue("@SName", s.SName);
            cmd.Parameters.AddWithValue("@Marks", s.Marks);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateStudent(Student s)
        {
            cmd = new SqlCommand("Update Student Set SName = @sName,Marks = @Marks Where Rno = @Rno", conn);
            cmd.Parameters.AddWithValue("@Rno", s.Rno);
            cmd.Parameters.AddWithValue("@SName", s.SName);
            cmd.Parameters.AddWithValue("@Marks", s.Marks);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteStudent(int id)
        {
            cmd = new SqlCommand("Delete From STudent Where Rno = @Rno", conn);
            cmd.Parameters.AddWithValue("@Rno", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Student SearchStudent(int id)
        {
            cmd = new SqlCommand("Select * From Student Where Rno= @Rno", conn);
            cmd.Parameters.AddWithValue("@Rno", id);
            conn.Open();
            dr = cmd.ExecuteReader();
            
            Student s = new Student();
            if (dr.Read())
            {

                s.Rno = int.Parse(dr["Rno"].ToString());
                s.SName = dr["SName"].ToString();
                s.Marks = int.Parse(dr["Marks"].ToString());
               
            }
            return s;
            conn.Close();

        }

        public List<Student> GetAllStudent()
        {
            cmd = new SqlCommand("Select * From Student", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            List<Student> slist = new List<Student>();
            while(dr.Read())
            {
                Student s = new Student();
                s.Rno = int.Parse(dr["Rno"].ToString());
                s.SName = dr["SName"].ToString();
                s.Marks = int.Parse(dr["Marks"].ToString());
                slist.Add(s);
            }
            return slist;
        }
    }
}