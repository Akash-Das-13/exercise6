using KeepNote.DAL;
using KeepNote.DAL.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace test
{
  [TestCaseOrderer("test.PriorityOrderer", "test")]
  public class NoteRepositoryTest : IClassFixture<NoteDbSetup>
  {
    private readonly string constr;
    public NoteRepositoryTest(NoteDbSetup setup)
    {
      constr = Environment.GetEnvironmentVariable("MSSQL_URL");
      if (constr == null)
      {
        constr = @"server=.\sqlexpress01;database=keepnote_db;integrated security=true";
      }
    }

    [Fact,TestPriority(0)]
    public void TestGetAllNotes()
    {

      NoteRepository noteRepository = new NoteRepository(constr);


      List<Note> noteList = noteRepository.GetAllNotes();

      Assert.Equal(2, noteList.Count);
    }


    [Fact,TestPriority(1)]
    public void TestAddNote()
    {
      NoteRepository noteRepository = new NoteRepository(constr);

      Note newNote = new Note
      {
        NoteId = 1003,
        Title = "Submit Evaluation Report",
        Description = "submit assignment evaluation report",
        CreatedBy = 102
      };

      int records = noteRepository.AddNote(newNote);
      Assert.Equal(1, records);
    }
    
  }
}
