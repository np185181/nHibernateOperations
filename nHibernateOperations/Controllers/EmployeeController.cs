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
        public ActionResult Details(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
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
        public ActionResult Create(Employee emp)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(emp);
                    transaction.Commit();
                }
            }

            return View(emp);
        }
                
        // GET: /Employees/Edit/5
        public ActionResult Edit(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        // POST: /Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Employee emp)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                employee.Name = emp.Name;
                employee.Designation = emp.Designation;
                employee.Role = emp.Role;
                employee.Gender = emp.Gender;
                employee.Salary = emp.Salary;
                employee.City = emp.City;
                employee.State = emp.State;
                employee.Zip = emp.Zip;
                employee.Address = emp.Address;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: /Employees/Delete/5
        public ActionResult Delete(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                return View(employee);
            }
        }

        // POST: /Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, Employee emp)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(emp);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }
    }
}