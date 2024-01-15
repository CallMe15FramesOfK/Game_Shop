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
    public class User_ListController : Controller
    {
        private readonly ApplicationDBContext _context;

        public User_ListController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: User_List
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_List.ToListAsync());
        }

        // GET: User_List/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_List = await _context.User_List
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_List == null)
            {
                return NotFound();
            }

            return View(user_List);
        }

        // GET: User_List/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_List/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameShopEntityId,GameName,GamePlatform,GameGenre")] User_List user_List)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_List);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_List);
        }

        // GET: User_List/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_List = await _context.User_List.FindAsync(id);
            if (user_List == null)
            {
                return NotFound();
            }
            return View(user_List);
        }

        // POST: User_List/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameShopEntityId,GameName,GamePlatform,GameGenre")] User_List user_List)
        {
            if (id != user_List.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_List);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_ListExists(user_List.Id))
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
            return View(user_List);
        }

        // GET: User_List/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_List = await _context.User_List
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_List == null)
            {
                return NotFound();
            }

            return View(user_List);
        }

        // POST: User_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_List = await _context.User_List.FindAsync(id);
            if (user_List != null)
            {
                _context.User_List.Remove(user_List);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_ListExists(int id)
        {
            return _context.User_List.Any(e => e.Id == id);
        }
    }
}
