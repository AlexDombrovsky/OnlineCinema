using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Data;
using OnlineCinema.Interfaces;
using OnlineCinema.Models;

namespace OnlineCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IMovieService movieService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1 || page > 1000)
                page = 1;
            const int pageSize = 3;
            var movies = await _movieService.MoviePerPages(page, pageSize);
            var model = new PageMovieViewModel
            {
                Items = _mapper.Map<List<MovieViewModel>>(movies),
                Pager = new Pager(await _movieService.MovieCount(), page, pageSize)
            };
            return View(model);
        }

        public async Task<string> UpdateImage(MovieViewModel model)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, WorkContext.ImagePath);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            var fileName = Guid.NewGuid() + Path.GetExtension(model.File.FileName);
            await using var fileSteam = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
            await model.File.CopyToAsync(fileSteam);

            if (model.Id != 0)
            {
                var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, WorkContext.ImagePath, model.Image);
                if (System.IO.File.Exists(oldFilePath)) System.IO.File.Delete(oldFilePath);
            }

            return fileName;
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            if (id.HasValue)
            {
                var movie = await _movieService.GetById(id);
                if (movie != null)
                {
                    var model = _mapper.Map<MovieViewModel>(movie);
                    if (User.Identity.IsAuthenticated && User.Identity.Name == model.User)
                        return View(model);
                }
            }
            else
            {
                var model = new MovieViewModel();
                if (User.Identity.IsAuthenticated)
                    return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(MovieViewModel model)
        {
            if (string.IsNullOrEmpty(model.Image) && model.File == null)
            {
                ModelState.AddModelError("File", "Постер должен быть загружен!");
                return View(model);
            }

            var fileName = "";
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                if (model.File != null && model.File.Length > 0) fileName = UpdateImage(model).Result;

                var movie = _mapper.Map<Movie>(model);
                movie.User = User.Identity.Name;
                if (model.Id == 0)
                {
                    movie.Image = fileName;
                    await _movieService.Add(movie);
                }
                else
                {
                    if (User.Identity.Name == movie.User)
                    {
                        movie.Image = model.File != null ? fileName : model.Image;
                        await _movieService.Update(movie);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var movie = _movieService.GetById(id).Result;
            var model = _mapper.Map<MovieViewModel>(movie);
            return View(model);
        }

        //TODO: решить проблему с 405 ошибкой при HttpDelete
        public async Task<IActionResult> Delete(int id)
        {
            var movie = _movieService.GetById(id).Result;
            if (movie != null && movie.User == User.Identity.Name)
            {
                var result = await _movieService.Delete(id);
                if (result)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, WorkContext.ImagePath, movie.Image);
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}