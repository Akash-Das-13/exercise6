using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KeepNote.DAL.Entities;

namespace KeepNote.DAL
{
  public class UserRepository
  {

        /*
          Declare variables of type SqlConnection and SqlCommand
        */
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter sda;
        DataSet dataSet;

    public UserRepository(string connectionString)
    {
            /*
              1. create SqlConnection instance with connectionString passed
              2. create SqlDataAdapter instance for users table
              3. create DataSet instance
              4. populate DataSet with records fetched

             */

            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            sda = new SqlDataAdapter("select * from Users",connectionString);
            dataSet = new DataSet();
            sda.Fill(dataSet, "UsersDs");
    }

    public List<User> GetAllUsers()
    {
            /*
              1. Traverse through the rows in table Users of DataSet
              2. For each row, populate the user object
              3. Populate list with user object
              4. return the list
             */
            List<User> usersList = new List<User>();
            foreach(DataRow dataRow in dataSet.Tables["UsersDs"].Rows)
            {
                User user = new User();
                user.UserId= Convert.ToInt32(dataRow["userId"]);
                user.UserName = dataRow["userName"].ToString();
                user.Password = dataRow["password"].ToString();
                user.Email = dataRow["email"].ToString();

                usersList.Add(user);
            }
            return usersList;
    }

    public int AddUser(User user)
    {

            /*
              1. create new DataRow
              2. populate the new DataRow with user values
              3. add this DataRow to the Rows of DataTable for Users 
              4. return the count of records
            */
            DataRow dataRow2 = dataSet.Tables["UsersDs"].NewRow();
            dataRow2["UserId"] = user.UserId;
            dataRow2["UserName"] = user.UserName;
            dataRow2["Password"] = user.Password;
            dataRow2["Email"] = user.Email;

            dataSet.Tables["UsersDs"].Rows.Add(dataRow2);
            int count = dataSet.Tables["UsersDs"].Rows.Count;
            return count;
    }

    public int SaveChanges()
    {
            /*
              using SqlCommandBuilder update the Users table with User Records from DataSet

             */
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            int changes=sda.Update(dataSet, "UsersDs");
            //int count = dataSet.Tables["UsersDs"].Rows.Count;
            return changes;
            //return changes;
    }
  }
}
