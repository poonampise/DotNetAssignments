using ModelBindingAndDbCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ModelBindingAndDbCode.Controllers
{
    public class EmployeesController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Employees
        public ActionResult Index()
        {
            var getemprecords = dc.CRUDEmp(null, null, null, null, "Select").ToList();
           
            return View(getemprecords);

        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
            var empdetails = dc.CRUDEmp(id, null, null, null, "Details").Single(x => x.EmpNo == id);
            return View(empdetails);
        }

        // GET: Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee Collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.CRUDEmp(Collection.EmpNo, Collection.Name, Collection.Basic, Collection.DeptNo, "Insert");
                dc.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id=0)
        {
            var empdetails = dc.CRUDEmp(id, null, null, null, "Details").Single(x => x.EmpNo == id);
            return View(empdetails);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Employee collection)
        {
            try
            {
                // TODO: Add update logic here
                dc.CRUDEmp(id, collection.Name, collection.Basic, collection.DeptNo, "Update");
                dc.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            var empdetails = dc.CRUDEmp(id, null, null, null, "Details").Single(x => x.EmpNo == id);
            return View(empdetails);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                // TODO: Add delete logic here
                dc.CRUDEmp(id, null, null, null, "Delete");
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
