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
    public class IndexModel : PageModel
    {
        private readonly GardenControl2.Data.DbContextGardenControl2 _context;

        public IndexModel(GardenControl2.Data.DbContextGardenControl2 context)
        {
            _context = context;
        }

        public IList<Unidad> Unidad { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Unidades != null)
            {
                Unidad = await _context.Unidades.OrderBy(u => u.Orden)
                .Include(u => u.Curso).ToListAsync();
            }
        }
    }
}
