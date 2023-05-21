using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl2.Data;
using GardenControl2.Models;

namespace GardenControl2.Pages.GCUnidades
{
    public class DeleteModel : PageModel
    {
        private readonly GardenControl2.Data.DbContextGardenControl2 _context;

        public DeleteModel(GardenControl2.Data.DbContextGardenControl2 context)
        {
            _context = context;
        }

        [BindProperty]
      public Unidad Unidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades.FirstOrDefaultAsync(m => m.Id == id);

            if (unidad == null)
            {
                return NotFound();
            }
            else 
            {
                Unidad = unidad;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }
            var unidad = await _context.Unidades.FindAsync(id);

            if (unidad != null)
            {
                Unidad = unidad;
                _context.Unidades.Remove(Unidad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
