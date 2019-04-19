
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eproject.Models;
using System.Diagnostics;

namespace Eproject.Controllers
{
    [HandleError]
    public class StoreController : Controller
    {
        DataModel dm = new DataModel();
        
        public ActionResult Welcome()
        {
            List<product> p = dm.products.ToList();

            return View(p);
        }
        public ActionResult Contact()
        {
            return View();
        }
       
       
        public ActionResult Product(string id)
        {
            product pro = dm.products.Single(x=>x.Pro_ID==id);

            catagory cat = dm.catagories.Single(x=>x.Cat_ID==pro.Catogary);
            ViewBag.cat =  cat.Name;

            brand bra = dm.brands.Single(x => x.Brand_Id == pro.Brand);
            ViewBag.brand = bra.Brand_Name;

            shop_vendor sh = dm.shop_vendor.Single(x => x.Shop_Id == pro.Shop);
            ViewBag.shop = sh.Shop_Name;

           return View(pro);
        }
        public ActionResult Shop(string id)
        {
            shop_vendor sv = dm.shop_vendor.Single(x => x.Shop_Id == id);
            catagory cat = dm.catagories.Single(x=>x.Cat_ID==sv.Catagory);
            ViewBag.cat = cat.Name;
            return View(sv);
        }
        public ActionResult Displayproducts()
        {
            List<product> pro = dm.products.ToList();
            return View(pro);
        }
        public ActionResult DisplayShops()
        {
            List<shop_vendor> sh = dm.shop_vendor.ToList();
            return View(sh);
            
        }
        public ActionResult AddToCart(cart c){

            dm.carts.Add(c);
            dm.SaveChanges();   
           
            return Redirect(Request.UrlReferrer.ToString());
        
        }

        public ActionResult Cart() {
            //cart uid = new cart();
            string uid =  Session["User_ID"].ToString();
            List<cart> c = dm.carts.Where(x=>x.User_ID == uid.ToString()).ToList();
            return View(c);
        }
        public ActionResult DeleteCart(string id)
        {
            cart a = dm.carts.Single(x => x.Cart_ID == id);
            dm.carts.Remove(a);
            dm.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        
        public ActionResult Search(string keyword="no", string by="Default")
        {
            if (keyword=="no")
            {
                RedirectToAction("Welcome");
            }
            switch (by)
            {
                case "Default":
                    ViewBag.by = "no";
                    
            try
            {
                List<product> p = dm.products.Where(x=>x.Des.Contains(keyword) || x.Pro_Name.Contains(keyword)).ToList();
                if (p.Count ==0)
                {
                    ViewBag.product = "no";
                }
                else
                {
                    ViewBag.product = p;
                }
                
            }
            catch (Exception e)
            {
                ViewBag.product = "no";
            }
            try
            {
                List<shop_vendor> s = dm.shop_vendor.Where(x => x.Description.Contains(keyword) || x.Shop_Name.Contains(keyword)).ToList();
                if (s.Count==0)
                {
                    ViewBag.shop = "no";
                }
                else
                {
                    ViewBag.shop = s;
                }
                
            }
            catch (Exception e)
            {
                ViewBag.shop = "no";
            }
            

                    break;

                case "Cat":
                    
                        List<product> cp = dm.products.Where(x => x.Catogary == keyword).ToList();
                        ViewBag.by = cp;
                    break;

                case "Brand":
                    List<product> bp = dm.products.Where(x => x.Brand == keyword).ToList();
                        ViewBag.by = bp;
                    break;
                case "Shop":
                    List<product> sp = dm.products.Where(x => x.Shop == keyword).ToList();
                    ViewBag.by = sp;
                    break;
            }



            
            return View();
        }
    }
}
