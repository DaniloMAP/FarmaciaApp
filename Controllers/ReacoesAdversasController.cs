using FarmaciaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FarmaciaApp.Controllers
{
    public class ReacoesAdversasController : Controller
    {
        private readonly ApplicationContext _context;

        public ReacoesAdversasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ReacoesAdversas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReacoesAdversas.ToListAsync());
        }

        // GET: ReacoesAdversas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReacoesAdversas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] ReacaoAdversa reacaoAdversa)
        {
            
            
                _context.Add(reacaoAdversa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(reacaoAdversa);
        }

        // GET: ReacoesAdversas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reacaoAdversa = await _context.ReacoesAdversas.FindAsync(id);
            if (reacaoAdversa == null)
            {
                return NotFound();
            }
            return View(reacaoAdversa);
        }

        // POST: ReacoesAdversas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] ReacaoAdversa reacaoAdversa)
        {
            if (id != reacaoAdversa.Id)
            {
                return NotFound();
            }

           
            
                try
                {
                    _context.Update(reacaoAdversa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReacaoAdversaExists(reacaoAdversa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(reacaoAdversa);
        }

        // GET: ReacoesAdversas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reacaoAdversa = await _context.ReacoesAdversas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reacaoAdversa == null)
            {
                return NotFound();
            }

            return View(reacaoAdversa);
        }

        // POST: ReacoesAdversas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reacaoAdversa = await _context.ReacoesAdversas.FindAsync(id);
            _context.ReacoesAdversas.Remove(reacaoAdversa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReacaoAdversaExists(int id)
        {
            return _context.ReacoesAdversas.Any(e => e.Id == id);
        }
    }
}
