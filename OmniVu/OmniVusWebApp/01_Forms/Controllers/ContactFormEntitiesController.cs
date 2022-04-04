#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01_Forms.Models.Entities;
using _01_Forms.data;

namespace _01_Forms.Controllers
{
    public class ContactFormEntitiesController : Controller
    {
        private readonly SqlContext _context;

        public ContactFormEntitiesController(SqlContext context)
        {
            _context = context;
        }

        // GET: ContactFormEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactForms.ToListAsync());
        }

        // GET: ContactFormEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFormEntity = await _context.ContactForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactFormEntity == null)
            {
                return NotFound();
            }

            return View(contactFormEntity);
        }

        // GET: ContactFormEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactFormEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Message")] ContactFormEntity contactFormEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactFormEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactFormEntity);
        }

        // GET: ContactFormEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFormEntity = await _context.ContactForms.FindAsync(id);
            if (contactFormEntity == null)
            {
                return NotFound();
            }
            return View(contactFormEntity);
        }

        // POST: ContactFormEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Message")] ContactFormEntity contactFormEntity)
        {
            if (id != contactFormEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactFormEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactFormEntityExists(contactFormEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactFormEntity);
        }

        // GET: ContactFormEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFormEntity = await _context.ContactForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactFormEntity == null)
            {
                return NotFound();
            }

            return View(contactFormEntity);
        }

        // POST: ContactFormEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactFormEntity = await _context.ContactForms.FindAsync(id);
            _context.ContactForms.Remove(contactFormEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactFormEntityExists(int id)
        {
            return _context.ContactForms.Any(e => e.Id == id);
        }
    }
}
