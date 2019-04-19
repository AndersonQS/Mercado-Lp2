using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoLp2.Models;
using MercadoLp2.Data;

namespace MercadoLp2.Controllers
{
    public class ProdutosVendidosController : Controller
    {
        private readonly MercadoLp2Context _context;

        public ProdutosVendidosController(MercadoLp2Context context)
        {
            _context = context;
        }

        // GET: ProdutosVendidos
        public async Task<IActionResult> Index()
        {

            return View(Carrinho.Venda.Vendidos);
        }

        // GET: ProdutosVendidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosVendidos = await _context.ProdutosVendidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosVendidos == null)
            {
                return NotFound();
            }

            return View(produtosVendidos);
        }

        // GET: ProdutosVendidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutosVendidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qtde,Preco")] ProdutosVendidos produtosVendidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosVendidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtosVendidos);
        }

        // GET: ProdutosVendidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosVendidos = await _context.ProdutosVendidos.FindAsync(id);
            if (produtosVendidos == null)
            {
                return NotFound();
            }
            return View(produtosVendidos);
        }

        // POST: ProdutosVendidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qtde,Preco")] ProdutosVendidos produtosVendidos)
        {
            if (id != produtosVendidos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosVendidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosVendidosExists(produtosVendidos.Id))
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
            return View(produtosVendidos);
        }

        // GET: ProdutosVendidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosVendidos = await _context.ProdutosVendidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosVendidos == null)
            {
                return NotFound();
            }

            return View(produtosVendidos);
        }

        // POST: ProdutosVendidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtosVendidos = await _context.ProdutosVendidos.FindAsync(id);
            _context.ProdutosVendidos.Remove(produtosVendidos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosVendidosExists(int id)
        {
            return _context.ProdutosVendidos.Any(e => e.Id == id);
        }
    }
}
