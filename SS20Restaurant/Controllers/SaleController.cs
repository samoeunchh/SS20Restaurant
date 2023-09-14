using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS20Restaurant.Data;
using SS20Restaurant.Repository;

namespace SS20Restaurant.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _sale;
        private readonly AppDbContext _content;
        public SaleController(ISaleService sale, AppDbContext content)
        {
            _sale = sale;
            _content = content;
        }
        // GET: Sale
        public async Task<IActionResult> Index()
        {
            return View(await _sale.GetSale());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<JsonResult> GetProduct(Guid Id)
            => Json(await _content.Product.Where(x => x.CategoryId.Equals(Id)).ToListAsync());
        // GET: Sale/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Customer"] = new SelectList(_content.Customer, "CustomerId", "Name");
            ViewData["CategoryList"] = await _content.Category.ToListAsync();
            return View();
        }

        // POST: Sale/Create
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

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
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

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
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