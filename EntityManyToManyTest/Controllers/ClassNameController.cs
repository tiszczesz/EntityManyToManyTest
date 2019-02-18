using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityManyToManyTest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityManyToManyTest.Controllers
{
    public class ClassNameController : Controller {
        private readonly ApplicationDbContext _context;

        public ClassNameController(ApplicationDbContext context) {
            _context = context;
        }
        // GET: ClassName
        public async Task<IActionResult> Index() {
            var items = await _context.ClassNames.ToListAsync();
            return View(items);
        }

        // GET: ClassName/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassName/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassName/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassName/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassName/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassName/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}