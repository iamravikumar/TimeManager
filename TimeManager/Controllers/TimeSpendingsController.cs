using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeManager.Data;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class TimeSpendingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        public TimeSpendingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: TimeSpendings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeSpending.Include(t => t.Project).Include(t => t.Task).Include(t=>t.WorkerUser);
            return View(await applicationDbContext.ToListAsync());
        }

        public JsonResult GetTasks(int projectId)
        {
            return Json(_context.Task.Where(t => t.ProjectId == projectId).OrderBy(o => o.Name).ToList());
        }

        // GET: TimeSpendings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSpending = await _context.TimeSpending
                .Include(t => t.Project)
                .Include(t => t.Task)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (timeSpending == null)
            {
                return NotFound();
            }

            return View(timeSpending);
        }

        // GET: TimeSpendings/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name");
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Name");
            ViewBag.Users = new SelectList(userManager.Users.ToList(), "Id", "FullName");
            return View();
        }

        // POST: TimeSpendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProjectId,TaskId,Worker,TimeSpent,Status")] TimeSpending timeSpending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSpending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", timeSpending.ProjectId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Name", timeSpending.TaskId);
            ViewBag.Users = new SelectList(userManager.Users.ToList(), "Id", "FullName", timeSpending.Worker);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSpending = await _context.TimeSpending.SingleOrDefaultAsync(m => m.Id == id);
            if (timeSpending == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", timeSpending.ProjectId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Name", timeSpending.TaskId);
            ViewBag.Users = new SelectList(userManager.Users.ToList(), "Id", "FullName", timeSpending.Worker);
            return View(timeSpending);
        }

        // POST: TimeSpendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProjectId,TaskId,Worker,TimeSpent,Status")] TimeSpending timeSpending)
        {
            if (id != timeSpending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSpending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSpendingExists(timeSpending.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", timeSpending.ProjectId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Name", timeSpending.TaskId);
            ViewBag.Users = new SelectList(userManager.Users.ToList(), "Id", "FullName", timeSpending.Worker);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSpending = await _context.TimeSpending
                .Include(t => t.Project)
                .Include(t => t.Task)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (timeSpending == null)
            {
                return NotFound();
            }

            return View(timeSpending);
        }

        // POST: TimeSpendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeSpending = await _context.TimeSpending.SingleOrDefaultAsync(m => m.Id == id);
            _context.TimeSpending.Remove(timeSpending);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSpendingExists(int id)
        {
            return _context.TimeSpending.Any(e => e.Id == id);
        }
    }
}
