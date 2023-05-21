using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl2.Data;
using GardenControl2.Models;

namespace GardenControl2.Pages.GCLecciones
{
    public class DetailsModel : PageModel
    {
        private readonly GardenControl2.Data.DbContextGardenControl2 _context;

        public DetailsModel(GardenControl2.Data.DbContextGardenControl2 context)
        {
            _context = context;
        }

      public Leccion Leccion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lecciones == null)
            {
                return NotFound();
            }

            var leccion = await _context.Lecciones.FirstOrDefaultAsync(m => m.Id == id);
            if (leccion == null)
            {
                return NotFound();
            }
            else 
            {
                Leccion = leccion;
            }
            return Page();
        }
    }
}
