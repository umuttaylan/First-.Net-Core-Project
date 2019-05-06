using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstTry.Entities.Concrete;
using FirstTry.Services;

namespace FirstTry.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _context;

        public StudentsController(IStudentRepository context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View(_context.GetAll());
        }


        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Ad,Soyad,No")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        //GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Ad,Soyad,No")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Edit(student);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _context.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Get(id);
            _context.Delete(student);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
