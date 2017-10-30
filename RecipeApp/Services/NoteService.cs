using RecipeApp.Repositories;
using RecipeApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApp.Models;

namespace RecipeApp.Services
{
    public class NoteService
    {
        private NoteRepo _nRepo;
        private UserRepo _uRepo;

        public NoteService(NoteRepo nr, UserRepo ur)
        {
            _nRepo = nr;
            _uRepo = ur;
        }

        public IList<NoteDTO> GetMyNotes(string user)
        {
            return (from n in _nRepo.GetMyNotes(user)
                    select new NoteDTO()
                    {
                        Id = n.Id,
                        Text = n.Text,
                        DateAdded = n.DateAdded
                    }).ToList();
        }

        public NoteDTO GetById(int id)
        {
            return (from n in _nRepo.GetNoteById(id)
                    select new NoteDTO()
                    {
                        Id = n.Id,
                        Text = n.Text,
                        DateAdded = n.DateAdded
                    }).FirstOrDefault();
        }



        public void AddNote(NoteDTO note, string user)
        {
            Note dbNote = new Note()
            {
                Id = note.Id,
                Text = note.Text,
                DateAdded = DateTime.Now,
                UserId = _uRepo.getCurrentUser(user).First().Id
            };
            _nRepo.AddNote(dbNote);
        }

    }
}
