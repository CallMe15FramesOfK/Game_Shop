using Game_Shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Game_ShopController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Game_ShopController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Game_ShopController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Game_ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Game_ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game_ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Game_ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Game_ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Game_ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Game_ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
