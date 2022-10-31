using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleGastos.Data;
using ControleGastos.Models;

namespace ControleGastos.Controllers
{
    public class TransacaosController : Controller
    {
        private readonly ControleContext _context;

        public TransacaosController(ControleContext context)
        {
            _context = context;
        }

        // GET: Transacaos
        public async Task<IActionResult> Index()
        {
            var controleContext = _context.Transacao.Include(t => t.Pessoa);
            return View(await controleContext.ToListAsync());
        }

        // GET: Transacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacaos/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Nome");
            return View();
        }

        // POST: Transacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PessoaId,Descricao,Tipo,Valor,DataRegistro")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // GET: Transacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // POST: Transacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PessoaId,Descricao,Tipo,Valor,DataRegistro")] Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // GET: Transacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transacao == null)
            {
                return Problem("Entity set 'ControleContext.Transacao'  is null.");
            }
            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao != null)
            {
                _context.Transacao.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.Transacao.Any(e => e.Id == id);
        }
    }
}
