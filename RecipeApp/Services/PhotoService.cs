using RecipeApp.Models;
using RecipeApp.Repositories;
using RecipeApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class PhotoService
    {
        private PhotoRepo _pRepo;

        public PhotoService(PhotoRepo pr)
        {
            _pRepo = pr;
        }

        public IList<PhotoDTO> GetPhotos()
        {
            return (from p in _pRepo.GetPhotos()
                    select new PhotoDTO()
                    {
                        DateAdded = p.DateAdded,
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Title = p.Title
                    }).ToList();
        }

        public PhotoDTO GetPicById(int id)
        {
            return (from p in _pRepo.GetPicById(id)
                    select new PhotoDTO()
                    {
                        DateAdded = p.DateAdded,
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Title = p.Title
                    }).FirstOrDefault();
        }

        public void AddPhoto(PhotoDTO pic)
        {
            var dbPhoto = new Photo()
            {
                DateAdded = DateTime.Now,
                ImageUrl = pic.ImageUrl,
                Title = pic.Title
            };

            _pRepo.AddPhoto(dbPhoto);
        }

        public void DeletePhoto(PhotoDTO pic)
        {
            _pRepo.DeletePhoto(_pRepo.GetPicById(pic.Id).First());
        }

    }
}
