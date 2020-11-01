using System;
using System.Collections.Generic;
using System.Text;

namespace KeepNote.DAL.Entities
{
  public class User
  {

    /*
       This class should have four properties (UserId, UserName, Password and Email). 

       UserId - int
       UserName - string
       Password - string
       Email - string

    */
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

  }
}
