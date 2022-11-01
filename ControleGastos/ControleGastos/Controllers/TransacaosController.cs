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

        private bool TransacaoExists(int id)
        {
          return _context.Transacao.Any(e => e.Id == id);
        }
    }
}
