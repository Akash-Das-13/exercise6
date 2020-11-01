using System;
using System.Collections.Generic;
using System.Text;

namespace KeepNote.DAL.Entities
{
  public class Note
  {
    /*
       This class should have four properties (NoteId, Title, Description and CreatedBy)
       NoteId - int
       Title - string
       Description - string
       CreatedBy - int
    */
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreatedBy { get; set; }
 
  }
}
