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
      string constr = Environment.GetEnvironmentVariable("MSSQL_URL");
      if (constr == null)
      {
        constr = @"server=.\sqlexpress01;database=keepnote_db;integrated security=true";
      }
      con = new SqlConnection(constr);
      con.Open();
      cmd = new SqlCommand();
      cmd.Connection = con;

      
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

       
      cmd.Dispose();
      con.Close();
      con.Dispose();
    }
  }
}
