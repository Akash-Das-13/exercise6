using System;
using System.Data.SqlClient;

namespace test
{
  public class NoteDbSetup : IDisposable
  {
    SqlConnection con;
    SqlCommand cmd;
    public NoteDbSetup()
    {
      con = new SqlConnection(@"server=.\sqlexpress;database=keepnote_db;integrated security=true");
      con.Open();
      cmd = new SqlCommand();
      cmd.Connection = con;

      //cmd.CommandText = "create table users (userid int, username varchar(20), password varchar(15), email varchar(30))";
      //cmd.ExecuteNonQuery();

      //cmd.CommandText = "insert into users values(101,'nandita','nandita@123','nandita@stackroute.in'),(102,'vikram','vikram@123','vikram@stackroute.in')";
      //cmd.ExecuteNonQuery();

      cmd.CommandText = "create table notes (noteid int, title varchar(30), description varchar(80), createdby int)";
      cmd.ExecuteNonQuery();

      cmd.CommandText = "insert into notes values(1001,'review assignment','reviewing ui assignments',101),(1002,'update status tracker','update tracker for completed assignments',101)";
      cmd.ExecuteNonQuery();

      con.Close();

    }

    public void Dispose()
    {
      if (con.State == System.Data.ConnectionState.Closed)
        con.Open();

      cmd.CommandText = "drop table notes";
      cmd.ExecuteNonQuery();

      //cmd.CommandText = "drop table users";
      //cmd.ExecuteNonQuery();

      cmd.Dispose();
      con.Close();
      con.Dispose();
    }
  }
}