﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registrera.se.Data;
using Registrera.se.Models;

namespace Registrera.se.Controllers
{
    [Authorize(Roles = "Administrator,Teacher")]
    public class CoursesController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Courses
        public async Task<IActionResult> Index( string sortId, string searchString)
        {
            ViewData["TitleSortingParm"] = string.IsNullOrEmpty(sortId) ? "titleDesc" : "";
            ViewData["StartDateSortingParm"] = sortId == "startDate" ? "startDateDesc" : "startDate";
            ViewData["EndDateSortingParm"] = sortId == "endDate" ? "endDateDesc" : "endDate";
            ViewData["CountrySortingParm"] = sortId == "country" ? "countryDesc" : "country";
            ViewData["CurrentSearch"] = searchString; 
            var courses = from s in _context.Courses select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Title.Contains(searchString) ||
                                            s.City.Contains(searchString) ||
                                            s.Teacher.Contains(searchString));

            }
            switch (sortId)
            {
                case "titleDesc":
                    courses = courses.OrderByDescending(s => s.Title);
                    break;

                case "startDate":
                    courses = courses.OrderBy(s => s.StartDate);
                    break;

                case "startDateDesc":
                    courses = courses.OrderByDescending(s => s.StartDate);
                    break;

                case "endDate":
                    courses = courses.OrderBy(s => s.EndDate);
                    break;

                case "endDateDesc":
                    courses = courses.OrderByDescending(s => s.EndDate);
                    break;
                default:
                    courses = courses.OrderBy(s => s.Title);
                    break;
            }
            return View(await courses.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> UserCourses()
        {
            var name = User.FindFirst(ClaimTypes.Name).Value;
            
            var courses = from s in _context.Courses select s;
            courses = courses.Where(c => c.Teacher == name);
          


            return View(await courses.AsNoTracking().ToListAsync());
        }

            // GET: Courses/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            var name = User.FindFirst(ClaimTypes.Name).Value;
            ViewBag.name = name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,About, Country, City, School, Teacher, StartDate,EndDate")] CourseDetails courseDetails)
        {
            if (ModelState.IsValid)
            {
                
                var name = User.FindFirst(ClaimTypes.Name).Value;
                ViewBag.name = name;
                courseDetails.Teacher = name;
         

                //var teacher = User.FindFirst("UserName").Value;
                //var teacher1 = await _userManager.FindByIdAsync(User.Identity.Name) as Teacher;
                //// if(teacher == null) { return View(courseDetails); }


                _context.Add(courseDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseDetails);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.Courses.FindAsync(id);
            if (courseDetails == null)
            {
                return NotFound();
            }
            return View(courseDetails);
        }

        // POST: Courses/Edit/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,About, Country, City, School, Teacher, StartDate,EndDate")] CourseDetails courseDetails)
        {
            if (id != courseDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDetailsExists(courseDetails.Id))
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
            return View(courseDetails);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseDetails = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDetailsExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
