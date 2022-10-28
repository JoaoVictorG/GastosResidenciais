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
    public class TransacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transacoes.Include(t => t.Pessoa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacao/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id");
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PessoaId,Descricao,Tipo,Valor")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PessoaId,Descricao,Tipo,Valor")] Transacao transacao)
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", transacao.PessoaId);
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacoes
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transacoes'  is null.");
            }
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao != null)
            {
                _context.Transacoes.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.Transacoes.Any(e => e.Id == id);
        }
    }
}
