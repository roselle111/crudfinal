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

            return RedirectToAction("login");
        }

        public ActionResult UserUpdate()
        {
            enemyEntities rdbe = new enemyEntities();
            user u = (from a in rdbe.users
                      where a.userId == 1
                      select a).FirstOrDefault();
            u.firstname = "Roselle";
            u.lastname = "Cutamora";
            u.email = "Roselle@gmail.com";
            u.password = "guapa kaayo";
            u.roleID = 1;
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult UserDelete()
        {
            enemyEntities rdbe = new enemyEntities();
            user u = (from a in rdbe.users
                      where a.userId == 2
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return View();
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