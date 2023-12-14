﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["firstname"];
            String lastName = fc["lastname"];
            String email = fc["email"];
            String diko = fc["password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.roleID = 1;

            enemyEntities fe = new enemyEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("ShowUser");
        }

        public ActionResult UserUpdate(int id)
        {



            enemyEntities user = new enemyEntities();

            var selectedUser = (from a in user.users where a.userId == id select a).ToList();


            ViewData["User"] = selectedUser;

            return View();
            //  return RedirectToAction("UserUpdate");  // Redirect to the appropriate action or view
        }
        public ActionResult Update(FormCollection fc, int id)
        {
            enemyEntities rdbe = new enemyEntities();
            user u = (from a in rdbe.users
                      where a.userId == id
                      select a).FirstOrDefault();

            String new_first_name = fc["new_firstname"];
            String new_last_name = fc["new_lastname"];
            String new_email = fc["new_email"];
            String new_address = fc["new_address"];
            String new_password = fc["new_password"];

            u.firstname = new_first_name;
            u.lastname = new_last_name;
            u.password = new_password;
            u.email = new_email;

            rdbe.SaveChanges();

            return RedirectToAction("ShowUser");
        }


        public ActionResult UserDelete(int id)
        {
            enemyEntities rdbe = new enemyEntities();
            user u = (from a in rdbe.users
                      where a.userId == id
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return RedirectToAction("ShowUser");
        }

        public ActionResult ShowUser()
        {
            enemyEntities fe = new enemyEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }

    }

}