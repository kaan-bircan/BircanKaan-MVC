#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Entities;
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        // TODO: Add service injections here
        private readonly IStudentService _studentService;
        private readonly IGradeService _gradeService;

        public StudentsController(IStudentService studentService, IGradeService gradeService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
        }

        // GET: Students
        public IActionResult Index()
        {
            List<StudentModel> studentList = _studentService.Query().ToList(); // TODO: Add get list service logic here
            return View(studentList);
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            StudentModel student = _studentService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["GradeId"] = new SelectList(_gradeService.Query().ToList(), "Value", "Text");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel student)
        {
			if (ModelState.IsValid)
			{
				// TODO: Add insert service logic here
				bool result = _studentService.Add(student);
				if (result)
				{
					TempData["Message"] = "Student created successfully.";
					return RedirectToAction(nameof(Index));
				}
				ModelState.AddModelError("", "Student could not be created!");
			}
			// TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			ViewData["GradeId"] = new SelectList(_gradeService.Query().ToList(), "Id", "Name");
			return View(student);
		}

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            StudentModel student = _studentService.Query().SingleOrDefault(s => s.Id == id); ; // TODO: Add get item service logic here
			if (student == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["GradeId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(student);
        }

        // POST: Students/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel student)
        {
			if (ModelState.IsValid)
			{
				// TODO: Add update service logic here
				bool result = _studentService.Update(student);
				if (result)
				{
					TempData["Message"] = "Student updated successfully.";
					return RedirectToAction(nameof(Index));
				}
				ModelState.AddModelError("", "Student could not be updated!");
			}
			// TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			ViewData["GradeId"] = new SelectList(_gradeService.Query().ToList(), "Value", "Text");
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            StudentModel student = _studentService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
			bool result = _studentService.Delete(id);
            if (result)
            {
               TempData["Message"] = "Student deleted successfully.";
               return RedirectToAction(nameof(Index));
            }
			TempData["Message"] = "Student could not be deleted.";
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
		}
	}
}
