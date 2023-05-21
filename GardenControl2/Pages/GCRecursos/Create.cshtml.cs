﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenControl2.Data;
using GardenControl2.Models;

namespace GardenControl2.Pages.GCRecursos
{
    public class CreateModel : PageModel
    {
        private readonly GardenControl2.Data.DbContextGardenControl2 _context;

        public CreateModel(GardenControl2.Data.DbContextGardenControl2 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LeccionId"] = new SelectList(_context.Lecciones, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Recurso Recurso { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recursos.Add(Recurso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
