using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Game_Shop.Areas.Identity.Data;
using Game_Shop.Entities;

namespace Game_Shop.Controllers
{
    public class GameShopEntitiesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public GameShopEntitiesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: GameShopEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameShopEntity.ToListAsync());
        }

        // GET: GameShopEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameShopEntity = await _context.GameShopEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameShopEntity == null)
            {
                return NotFound();
            }

            return View(gameShopEntity);
        }

        // GET: GameShopEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameShopEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Platform,Genre")] GameShopEntity gameShopEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameShopEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameShopEntity);
        }

        // GET: GameShopEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameShopEntity = await _context.GameShopEntity.FindAsync(id);
            if (gameShopEntity == null)
            {
                return NotFound();
            }
            return View(gameShopEntity);
        }

        // POST: GameShopEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Platform,Genre")] GameShopEntity gameShopEntity)
        {
            if (id != gameShopEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameShopEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameShopEntityExists(gameShopEntity.Id))
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
            return View(gameShopEntity);
        }

        // GET: GameShopEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameShopEntity = await _context.GameShopEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameShopEntity == null)
            {
                return NotFound();
            }

            return View(gameShopEntity);
        }

        // POST: GameShopEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameShopEntity = await _context.GameShopEntity.FindAsync(id);
            if (gameShopEntity != null)
            {
                _context.GameShopEntity.Remove(gameShopEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameShopEntityExists(int id)
        {
            return _context.GameShopEntity.Any(e => e.Id == id);
        }
    }
}
