﻿using AutoMapper;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
  public class EmployeeController : Controller
  {

    AppDbContext _db;
    IMapper _mapper;

    public EmployeeController(AppDbContext db, IMapper mapper)
    {
      _db = db;
      _mapper = mapper;
    }
    public IActionResult Index()
    {
      var empls = _db.Employees.Include(e => e.Department).Select(p=>p).ToList();
      var model = _mapper.Map<IEnumerable<EmployeeViewModel>>(empls);

      return View(model);
    }

    public IActionResult Create()
    {
      ViewBag.Departments = _db.Departments.ToList();
      return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeViewModel model)
    {
      ModelState.Remove("EmployeeId");

      if (ModelState.IsValid)
      {
        Employee employee = _mapper.Map<Employee>(model);

        _db.Add(employee);
        _db.SaveChanges();

        return RedirectToAction("Index");
      }

      return View();
    }

    public IActionResult Edit(int id)
    {
      Employee data = _db.Employees.Find(id); 
      EmployeeViewModel model = new EmployeeViewModel();

      if (data != null)
      {
        model = _mapper.Map<EmployeeViewModel>(data);
      }

      ViewBag.Departments = _db.Departments;
      return View("Create", model);

    }


    [HttpPost]
    public IActionResult Edit(EmployeeViewModel model)
    {

      if (ModelState.IsValid)
      {

        Employee employee = _mapper.Map<Employee>(model);
        _db.Employees.Update(employee);
        _db.SaveChanges();

        return RedirectToAction("Index");

      }

      ViewBag.Departments = _db.Departments.ToList();
      return View("Create", model);
    }

    public IActionResult Delete(int id)
    {
      Employee model = _db.Employees.Find(id);

      if (model != null)
      {
        _db.Employees.Remove(model);
        _db.SaveChanges();
      }

      return RedirectToAction("Index");

    }

  }
}
