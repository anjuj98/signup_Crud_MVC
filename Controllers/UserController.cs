using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_for_signup_using_MVC.DAL;
using CRUD_for_signup_using_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CRUD_for_signup_using_MVC.Controllers
{
    public class UserController : Controller
    {

        users_DAL users_DAL = new users_DAL();
        // GET: User
        public ActionResult Index()
        {
            var usersList = users_DAL.GetAllUsers();
            
            if(usersList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently user details not available in the database";
            }

            return View(usersList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase file)
        {
            try
            {
                bool IsInserted = false;

                if(ModelState.IsValid) 
                { 
                    IsInserted = users_DAL.InsertUserDetails(user, file, Server);

                    if(IsInserted) 
                    {
                        TempData["SuccessMessage"] = "User details saved successfully....!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save user details.";

                    }
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var users=users_DAL.GetUsersDetailsById(id).FirstOrDefault();

            if(users == null)
            {
                TempData["InfoMessage"] = "User details not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        
    }
}
