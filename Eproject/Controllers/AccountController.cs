using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eproject.Models;
using System.IO;

namespace Eproject.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        public ActionResult Login() {
            string user = Session["User_Type"].ToString();
            if (user == "Guest")
            {
            return View();
            }
            else if (user == "Admin")
            {
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Login(publicuseraccount ua)
        {
            using (DataModel db = new DataModel())
            {
                try
                {
                    var user = db.publicuseraccounts.Single(x => x.Email == ua.Email && x.Password == ua.Password);
                    if (user != null)
                    {
                        Session["Email"] = user.Email;
                        Session["User_ID"] = user.User_ID;
                        Session["User_Name"] = user.UserName;
                        Session["User_Type"] = user.UserType;
                        if (user.UserType=="Admin")
                        {
                        return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Welcome", "Store");
                        }
                        
                    }
                    else
                    {
                        ViewBag.Message = "Invalid username or password".ToString();
                        //ModelState.AddModelError("", "Invalid username or password");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Invalid username or password".ToString();
                    //ModelState.AddModelError("", "Invalid username or password"+e);
                    
                }

                return RedirectToAction("Welcome","Store");
            }
            
        }



        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(publicuseraccount ua)
        {

            using (DataModel db = new DataModel())
                    {
                        db.publicuseraccounts.Add(ua);
                        db.SaveChanges();
                        return RedirectToAction("Welcome","Store");
                    }
              
            return RedirectToAction("Login","Account");

        }


        public ActionResult Logout() {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");

            Session["Email"] = "Guest";
            Session["User_ID"] = path;
            Session["User_Name"] = "Guest";
            Session["User_Type"] = "Guest";

            return RedirectToAction("Welcome","Store");
        }
    }
}
