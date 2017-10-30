using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class NoteRepo
    {
        private ApplicationDbContext _db;

        public NoteRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Note> GetMyNotes(string user)
        {
            return from n in _db.Notes
            where n.User.UserName == user
            orderby n.DateAdded
            select n;
        }

        public IQueryable<Note> GetNoteById(int id)
        {
            return from n in _db.Notes
                   where n.Id == id
                   select n;
        }

        public void AddNote(Note note)
        {
            _db.Notes.Add(note);
            _db.SaveChanges();
        }
    }
}
