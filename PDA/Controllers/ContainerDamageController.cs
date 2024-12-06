using Microsoft.AspNetCore.Mvc;
using PDA.Models;
using Microsoft.EntityFrameworkCore;

namespace PDA.Controllers
{
    public class ContainerDamageController : Controller
    {
        //private readonly ApplicationContext _context;

        //public ContainerDamageController(ApplicationContext context)
        //{
        //    _context = context;
        //}

        //// READ: List all reports
        //public async Task<IActionResult> Index()
        //{
        //    var reports=await _context.ContainerDamageReports.ToListAsync();
        //    return View(reports);
        //}

        //// CREATE: Display the create form
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// CREATE: Save the report
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ContainerDamageReport report)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(report);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(report);
        //}

        //// EDIT: Display the edit form
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var report = await _context.ContainerDamageReports.FindAsync(id);
        //    if (report == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(report);
        //}

        //// EDIT: Update the report
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, ContainerDamageReport report)
        //{
        //    if (id != report.ContainerNumber)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(report);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(report);
        //}

        //// DELETE: Confirm deletion
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var report = await _context.ContainerDamageReports.FindAsync(id);
        //    if (report == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(report);
        //}

        //// DELETE: Remove the report
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var report = await _context.ContainerDamageReports.FindAsync(id);
        //    if (report != null)
        //    {
        //        _context.ContainerDamageReports.Remove(report);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //// DETAILS: View details of a report
        //public async Task<IActionResult> Details(int id)
        //{
        //    var report = await _context.ContainerDamageReports.FindAsync(id);
        //    if (report == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(report);
        //}
    }
}

