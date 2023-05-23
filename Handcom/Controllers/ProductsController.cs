using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handcom.Domain.Entities;
using Handcom.Infra.Data;
using Handcom.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using System.Buffers;
using Microsoft.Extensions.Caching.Memory;

namespace Handcom.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly ISessionService _sessionService;
        private readonly IMemoryCache _cache;

        public ProductsController(IProductService service, ICategoryService categoryService, ISupplierService supplierService, ISessionService sessionService, IMemoryCache memory)
        {
            _service = service;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _sessionService = sessionService;
            _cache = memory;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? userId = null, string filter = null, int pageindex = 1, string sort = "Name")
        {
            if (userId is null && _cache.Get<int?>("user") == null)
                return View("Error");

            if (_cache.Get("user") == null)
                _cache.Set<int?>("user", userId);
            else
                userId = _cache.Get<int?>("user");
            var session = _sessionService.GetSession((int)userId);

            if (session is null || !session.IsActive)
                return View("Error");

            ViewBag.UserId = userId;

            var resultado = _service.GetAll().ToList();

            resultado.ForEach(c =>
            {
                c.Supplier = _supplierService.GetById(c.SupplierId);
                c.Category = _categoryService.GetById(c.CategoryId);
            });

            var products = resultado.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                products = products.Where(p => p.Name.Contains(filter) || p.Category.Name.Contains(filter) || p.Supplier.Name.Contains(filter) || p.Id.ToString().Contains(filter));
            }

            var model =  PagingList.Create(products, 2, pageindex, sort, "Name");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }


        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _service.GetById((int)id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll().ToList(), "Id", "Name");
            ViewBag.SupplierId = new SelectList(_supplierService.GetAll().ToList(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CategoryId,SupplierId,Description,CreatedAt")] Products products)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(products);
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _service.GetById((int)id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CategoryId,SupplierId,Description,CreatedAt")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(products);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _service.GetById((int)id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var products = _service.GetById(id);
            _service.Delete(products);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _service.GetAll().Any(e => e.Id == id);
        }
    }
}
