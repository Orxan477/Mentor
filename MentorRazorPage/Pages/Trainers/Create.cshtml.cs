using MentorRazorPage.DAL;
using MentorRazorPage.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MentorRazorPage.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public CreateModel(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [BindProperty]
        public Models.Trainer Trainers { get; set; }
        public void OnGet()
        {
        }


        #region MVM-Post
        //public async Task<IActionResult> OnPost(Models.Trainer Trainers)
        //{
        //if (!ModelState.IsValid) return Page();

        //bool isExistName =await  _context.Trainers.AnyAsync(i => i.Name.Trim().ToLower() == Trainers.Name.Trim().ToLower());
        //if (isExistName)
        //{
        //    ModelState.AddModelError("Name", "Multiple Name");
        //    return Page();
        //}
        //if (Trainers.Photo.Length/1024>200)
        //{
        //    ModelState.AddModelError("Photo", "Size>200");
        //    return Page();
        //}
        //if (!Trainers.Photo.ContentType.Contains("image/"))
        //{
        //    ModelState.AddModelError("Photo", "Type is incorrect");
        //    return Page();
        //}
        //string fileName = Guid.NewGuid().ToString() + "_" + Trainers.Photo.FileName;
        //string root = Path.Combine(_env.WebRootPath, "assets/img", fileName);
        //using(FileStream fileStream=new FileStream(root, FileMode.Create))
        //{
        //    await Trainers.Photo.CopyToAsync(fileStream);
        //}
        //Trainer newTrainer = new Trainer
        //{
        //    Name= Trainers.Name,
        //    Position= Trainers.Position,
        //    Image=fileName,
        //    Content= Trainers.Content
        //};
        //await _context.Trainers.AddAsync(newTrainer);
        //await _context.SaveChangesAsync();
        //return RedirectToPage("/Index");
    //}
            #endregion
        
    }
}
