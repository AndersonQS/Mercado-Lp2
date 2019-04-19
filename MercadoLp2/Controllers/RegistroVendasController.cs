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
    public class RegistroVendasController : Controller
    {
        private readonly MercadoLp2Context _context;

        public RegistroVendasController(MercadoLp2Context context)
        {
            _context = context;
        }

        // GET: RegistroVendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroVendas.ToListAsync());
        }

        // GET: RegistroVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVendas = await _context.RegistroVendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroVendas == null)
            {
                return NotFound();
            }

            return View(registroVendas);
        }

        // GET: RegistroVendas/Create
        public IActionResult Create()
        {
            RegistroVendas registroVendas = new RegistroVendas();

            foreach (ProdutosVendidos pv in Carrinho.listaCarrinho)
            {
                registroVendas.Vendidos.Add(pv);
            }
        
            return View(registroVendas);
        }

        // POST: RegistroVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Valor,Status")] RegistroVendas registroVendas)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(registroVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroVendas);
        }

        // GET: RegistroVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVendas = await _context.RegistroVendas.FindAsync(id);
            if (registroVendas == null)
            {
                return NotFound();
            }
            return View(registroVendas);
        }

        // POST: RegistroVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Valor,Status")] RegistroVendas registroVendas)
        {
            if (id != registroVendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroVendasExists(registroVendas.Id))
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
            return View(registroVendas);
        }

        public async void MostrarProdutos()
        {
            ProdutosVendidosController Pvc = new ProdutosVendidosController(_context);
            Pvc.Index();
        }

        // GET: RegistroVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVendas = await _context.RegistroVendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroVendas == null)
            {
                return NotFound();
            }

            return View(registroVendas);
        }

        // POST: RegistroVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroVendas = await _context.RegistroVendas.FindAsync(id);
            _context.RegistroVendas.Remove(registroVendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroVendasExists(int id)
        {
            return _context.RegistroVendas.Any(e => e.Id == id);
        }
    }
}
