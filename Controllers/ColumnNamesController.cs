using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPExcelNet5.Data;
using ASPExcelNet5.Models;

namespace ASPExcelNet5.Controllers
{
    public class ColumnNamesController : Controller
    {
        private readonly TablesExcelContext _context;

        public ColumnNamesController(TablesExcelContext context)
        {
            _context = context;
        }

        // GET: ColumnNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColumnNames.ToListAsync());
        }

        // GET: ColumnNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columnName = await _context.ColumnNames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (columnName == null)
            {
                return NotFound();
            }

            return View(columnName);
        }

        // GET: ColumnNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColumnNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title")] ColumnName columnName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(columnName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(columnName);
        }

        // GET: ColumnNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columnName = await _context.ColumnNames.FindAsync(id);
            if (columnName == null)
            {
                return NotFound();
            }
            return View(columnName);
        }

        // POST: ColumnNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title")] ColumnName columnName)
        {
            if (id != columnName.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(columnName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColumnNameExists(columnName.ID))
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
            return View(columnName);
        }

        // GET: ColumnNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columnName = await _context.ColumnNames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (columnName == null)
            {
                return NotFound();
            }

            return View(columnName);
        }

        // POST: ColumnNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var columnName = await _context.ColumnNames.FindAsync(id);
            _context.ColumnNames.Remove(columnName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColumnNameExists(int id)
        {
            return _context.ColumnNames.Any(e => e.ID == id);
        }
    }
}
