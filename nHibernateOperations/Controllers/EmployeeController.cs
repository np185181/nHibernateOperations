using NHibernate;
using nHibernateOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nHibernateOperations.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employees/List
        public ActionResult Index()
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employees = session.Query<Employee>().ToList();
                return View(employees);
            }
        }

        // GET: Employees/Details
        public ActionResult Details(int empId = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(empId);
                return View(employee);
            }
        }

        // GET: /Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employeeObj)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employeeObj);
                    transaction.Commit();
                }
            }

            return View(emp);
        }
                
        // GET: /Employees/Edit/5
        public ActionResult Edit(int empId = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(empId);
                return View(employee);
            }
        }

        // POST: /Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? empId, Employee employeeObj)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(empId);
                employee.Name = employeeObj.Name;
                employee.Designation = employeeObj.Designation;
                employee.Role = employeeObj.Role;
                employee.Gender = employeeObj.Gender;
                employee.Salary = employeeObj.Salary;
                employee.City = employeeObj.City;
                employee.State = employeeObj.State;
                employee.Zip = employeeObj.Zip;
                employee.Address = employeeObj.Address;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: /Employees/Delete/5
        public ActionResult Delete(int empId = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(empId);
                return View(employee);
            }
        }

        // POST: /Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int empId, Employee employeeObj)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(employeeObj);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
