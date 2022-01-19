using MentorRazorPage.DAL;
using MentorRazorPage.Models;
using MentorRazorPage.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MentorRazorPage.Areas.admin.Controllers
{
    [Area("Admin")]
    public class TrainerController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        private string _errorMessage;

        public TrainerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Trainers.Where(t=>t.IsDeleted==false).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (!ModelState.IsValid) return View(trainer);

            bool isExistName = await _context.Trainers.AnyAsync(i => i.IsDeleted == false &&
                                                        i.Name.Trim().ToLower() == trainer.Name.Trim().ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Name", "Multiple Name");
                return View(trainer);
            }
            if (!CheckImageValid(trainer.Photo,200))
            {
                ModelState.AddModelError("Photo", _errorMessage);
                return View(trainer);
            }
            string fileName=await Extension.SaveFileAsync(_env.WebRootPath, "assets/img", trainer.Photo);

            Trainer newTrainer = new Trainer
            {
                Name = trainer.Name,
                Position = trainer.Position,
                Image = fileName,
                Content = trainer.Content
            };
            await _context.Trainers.AddAsync(newTrainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CheckImageValid(IFormFile file,int size)
        {
            if (!Extension.GetType(file))
            {
                _errorMessage = "Type is incorrect";
                return false;
            }
            if (!Extension.GetSize(file,size))
            {
                _errorMessage = "Size>200";
                return false;
            }
            return true;
        }
        public IActionResult Update(int id)
        {
            Trainer trainer = _context.Trainers.Find(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Trainer trainer)
        {
            if (!ModelState.IsValid) return View(trainer);
            Trainer dbtrainer = await _context.Trainers.Where(t=>t.IsDeleted==false && t.Id==id).FirstOrDefaultAsync();
            if (trainer == null) return NotFound();

            bool isExistName = await _context.Trainers.AnyAsync(i => i.IsDeleted == false && i.Name.Trim().ToLower() == trainer.Name.Trim().ToLower());
            bool isExistNameCurrent = dbtrainer.Name.Trim().ToLower() == trainer.Name.Trim().ToLower();
            if (isExistName && isExistNameCurrent==false)
            {
                ModelState.AddModelError("Name", "Multiple Name");
                return View(trainer);
            }
            if (!isExistNameCurrent)
            {
                dbtrainer.Name = trainer.Name;
            }
            bool isExistNameContent = dbtrainer.Content.Trim().ToLower() == trainer.Content.Trim().ToLower();
            if (!isExistNameContent)
            {
                dbtrainer.Content = trainer.Content;
            }
            bool isExistNamePosition = dbtrainer.Position.Trim().ToLower() == trainer.Position.Trim().ToLower();

            if (!isExistNamePosition)
            {
                dbtrainer.Position = trainer.Position;
            }
            if (!CheckImageValid(trainer.Photo,200))
            {
                ModelState.AddModelError("Photo", _errorMessage);
                return View(trainer);
            }

            string path = Path.Combine(_env.WebRootPath, "assets/img", dbtrainer.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            string fileName =await  Extension.SaveFileAsync(_env.WebRootPath, "assets/img", trainer.Photo);
            dbtrainer.Image = fileName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Trainer dbTrainer =await  _context.Trainers.Where(t => t.IsDeleted == false && t.Id == id).FirstOrDefaultAsync();
            if (dbTrainer == null) return NotFound();
            dbTrainer.IsDeleted = true ;
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
