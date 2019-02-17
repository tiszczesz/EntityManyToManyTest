using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityManyToManyTest.Data;
using EntityManyToManyTest.Models;
using EntityManyToManyTest.ModelViews;

namespace EntityManyToManyTest.Controllers
{
    public class ClassNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassNames
                .Include(c=>c.ClassNameTopics).ThenInclude(c=>c.Topic).ToListAsync());
        }

        // GET: ClassNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (className == null)
            {
                return NotFound();
            }

            return View(className);
        }

        // GET: ClassNames/Create
        public async Task<IActionResult> Create() {
            var vm = new ModelViewClassNameTopic();
            vm.Topics = await _context.Topics.ToListAsync();
            

            return View(vm);
        }

        // POST: ClassNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ClassName className)
        {
            if (ModelState.IsValid)
            {
                _context.Add(className);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(className);
        }

        // GET: ClassNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames.FindAsync(id);
            if (className == null)
            {
                return NotFound();
            }
            return View(className);
        }

        // POST: ClassNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ClassName className)
        {
            if (id != className.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(className);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassNameExists(className.Id))
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
            return View(className);
        }

        // GET: ClassNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (className == null)
            {
                return NotFound();
            }

            return View(className);
        }

        // POST: ClassNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var className = await _context.ClassNames.FindAsync(id);
            _context.ClassNames.Remove(className);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassNameExists(int id)
        {
            return _context.ClassNames.Any(e => e.Id == id);
        }
    }
}
