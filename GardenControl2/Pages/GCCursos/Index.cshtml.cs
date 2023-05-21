using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl2.Data;
using GardenControl2.Models;

namespace GardenControl2.Pages.GCCursos
{
    public class IndexModel : PageModel
    {
        private readonly GardenControl2.Data.DbContextGardenControl2 _context;

        public IndexModel(GardenControl2.Data.DbContextGardenControl2 context)
        {
            _context = context;
        }

        public IList<Curso> Curso { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cursos != null)
            {
                Curso = await _context.Cursos.ToListAsync();
                //SELECT * FROM CURSOS
            }
        }
    }
}
