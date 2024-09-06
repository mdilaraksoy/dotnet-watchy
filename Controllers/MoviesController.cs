using Microsoft.AspNetCore.Mvc;
using watchyproject.Models;
using System.Collections.Generic;
using System.Linq;
using watchyproject.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace watchyproject.Controllers
{
    
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _mvR;
        private readonly AppDbContext _context;
        public readonly MoviesModel mvm;

        public MoviesController(IMoviesRepository mvR, AppDbContext context)
        {
            _mvR = mvR;
            _context = context;
        }

        public IActionResult Index()
        {
            // database veri cekme
            var movies = _context.Movies.ToList();

            return View("Movies", movies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MoviesModel mvm)
        {

            if (ModelState.IsValid)
            {
               
                _mvR.Add(mvm);
                Console.WriteLine(mvm.Id);
                _mvR.Save();
                return RedirectToAction("Movies", "MoviesModel");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        System.Diagnostics.Debug.WriteLine(mvm.Id);
                        System.Diagnostics.Debug.WriteLine(mvm.Title);
                        System.Diagnostics.Debug.WriteLine(mvm.PosterUrl);
                        System.Diagnostics.Debug.WriteLine(mvm.Description);
                        System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            MoviesModel? mvm = _mvR.Get(x => x.Id == id);

            if (mvm == null)
            {
                return NotFound();
            }
            return View(mvm);
        }

        
        [HttpPost]

        public JsonResult DeleteMovie(MoviesModel m, int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                movie.IsActive = false; 
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
  