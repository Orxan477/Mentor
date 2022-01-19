using MentorRazorPage.DAL;
using MentorRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;
        public List<Trainer> Trainers { get; set; }
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
           Trainers= _context.Trainers.Where(t => t.IsDeleted == false).ToList();
        }
    }
}
