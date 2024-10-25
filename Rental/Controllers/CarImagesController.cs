using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Data.Models;

namespace Rental.Controllers
{
    public class CarImagesController : Controller
    {
        private readonly AppDBContent _context;

        public CarImagesController(AppDBContent context)
        {
            _context = context;
        }

        // GET: CarImages
        public async Task<IActionResult> Index()
        {
            var appDBContent = _context.CarImages.Include(c => c.Car);
            return View(await appDBContent.ToListAsync());
        }

        // GET: CarImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImages
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // GET: CarImages/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "id", "id");
            return View();
        }

        // POST: CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,CarId")] CarImage carImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "id", "id", carImage.CarId);
            return View(carImage);
        }

        // GET: CarImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImages.FindAsync(id);
            if (carImage == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "id", "id", carImage.CarId);
            return View(carImage);
        }

        // POST: CarImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,CarId")] CarImage carImage)
        {
            if (id != carImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarImageExists(carImage.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "id", "id", carImage.CarId);
            return View(carImage);
        }

        // GET: CarImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImages
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // POST: CarImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarImages == null)
            {
                return Problem("Entity set 'AppDBContent.CarImages'  is null.");
            }
            var carImage = await _context.CarImages.FindAsync(id);
            if (carImage != null)
            {
                _context.CarImages.Remove(carImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarImageExists(int id)
        {
          return (_context.CarImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
