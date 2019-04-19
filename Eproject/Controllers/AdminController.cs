using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eproject.Models;
using System.IO;
using System.Diagnostics;

namespace Eproject.Controllers
{

    [HandleError]
    public class AdminController : Controller
    {
        DataModel dm = new DataModel();

        
        
        public ActionResult Index()
        {
          return  RedirectToAction("AllProducts");
        }

        //product methods
        public ActionResult NewProduct()
        {
            List<brand> b = dm.brands.ToList();
            List<catagory> c = dm.catagories.ToList();
            List<shop_vendor> s = dm.shop_vendor.ToList();
            ViewBag.brand = b;
            ViewBag.cats = c;
            ViewBag.shop = s;

             return View();
        }
        [HttpPost]
        public ActionResult NewProduct(product p, HttpPostedFileBase ProductImage)
        {

           


            if (ProductImage != null && ProductImage.ContentLength > 0)
            {
                var fileType = Path.GetExtension(ProductImage.FileName);
                var fileName = Path.GetFileName(ProductImage.FileName);
                fileName = p.Pro_ID + fileType;
                var path = Path.Combine(Server.MapPath("~/Libs/Store/images/Product/"), fileName);
                ProductImage.SaveAs(path);

                p.Image = "~/Libs/Store/images/Product/" + fileName;
                dm.products.Add(p);
                dm.SaveChanges();
            }

            List<brand> b = dm.brands.ToList();
            List<catagory> c = dm.catagories.ToList();
            List<shop_vendor> s = dm.shop_vendor.ToList();
            ViewBag.brand = b;
            ViewBag.cats = c;
            ViewBag.shop = s;
            return View();
        }
        public ActionResult UpdateProduct(string id)
        {
                DataModel dm = new DataModel();
                product p = dm.products.Single(x => x.Pro_ID == id);

                ViewBag.catlist = dm.catagories.ToList();
                ViewBag.brandlist = dm.brands.ToList();
                ViewBag.shoplist = dm.shop_vendor.ToList();
                ViewBag.currentshop = dm.shop_vendor.Where(x => x.Shop_Id == p.Shop);
                ViewBag.currentcat = dm.catagories.Where(x => x.Cat_ID == p.Catogary);
                ViewBag.currentbrand = dm.brands.Where(x => x.Brand_Id == p.Brand);

            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateProduct(product p, HttpPostedFileBase ProductImage)
        {
            
                var a = dm.products.Where(k => k.Pro_ID == p.Pro_ID).FirstOrDefault();
                dm.products.Remove(a);
                dm.SaveChanges();

                var fileName = p.Image;
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    var fileType = Path.GetExtension(ProductImage.FileName);
                    fileName = Path.GetFileName(ProductImage.FileName);
                    fileName = p.Pro_ID + fileType;
                    var path = Path.Combine(Server.MapPath("~/Libs/Store/images/Product/"), fileName);
                    ProductImage.SaveAs(path);

                   
                }
                p.Image = "~/Libs/Store/images/Product/" + fileName;
                dm.products.Add(p);
                dm.SaveChanges();



                return RedirectToAction("ViewProduct", new { id=p.Pro_ID});
        }

        public ActionResult DeleteProduct(string id)
        {
            var a = dm.products.Where(k => k.Pro_ID == id).First();
            dm.products.Remove(a);
            dm.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AllProducts()
        {
            List<product> d = dm.products.ToList();
            return View(d);
        }

        public ActionResult ViewProduct(string id) {

           product p = dm.products.Where(k => k.Pro_ID == id).First();
           ViewBag.cat = dm.catagories.Where(x=>x.Cat_ID==p.Catogary);
           ViewBag.brand = dm.brands.Where(x => x.Brand_Id == p.Brand);
           ViewBag.shop = dm.shop_vendor.Where(x => x.Shop_Id == p.Shop);
           return View(p);
        }

        //product methods



        ////catagory methods
        public ActionResult AllCats()
        {
                List<catagory> d = dm.catagories.ToList();
                 return View(d);
        }
        

        [HttpPost]
        public ActionResult AddCats(catagory c) {
            dm.catagories.Add(c);
            dm.SaveChanges();
            return RedirectToAction("AllCats");
        }
        
        [HttpPost]
        public ActionResult UpdateCats(catagory c)
        {

            var a = dm.catagories.Where(k => k.Cat_ID == c.Cat_ID).First();
            dm.catagories.Remove(a);
            dm.SaveChanges();
            dm.catagories.Add(c);
            dm.SaveChanges();
            return RedirectToAction("AllCats","Admin");
        }
        public ActionResult DeleteCats(string id)
        {
            var a = dm.catagories.Where(k => k.Cat_ID == id).First();
            dm.catagories.Remove(a);
            dm.SaveChanges();
            return RedirectToAction("AllCats");
        }

        //catagory methods





        //Brands
        public ActionResult AllBrands()
        {
            List<brand> b = dm.brands.ToList();

            return View(b);
        }
        public ActionResult DeleteBrand(string id)
        {
            var a = dm.brands.Where(b=> b.Brand_Id == id).First();
            dm.brands.Remove(a);
            dm.SaveChanges();
            return RedirectToAction("AllBrands");
        }

         
        [HttpPost]
        public ActionResult AddBrand(brand b)
        {
            dm.brands.Add(b);
            dm.SaveChanges();
            return RedirectToAction("AllBrands");
        }
       
        [HttpPost]
        public ActionResult UpdateBrand(brand b)
        {
            var a = dm.brands.Where(d => d.Brand_Id == b.Brand_Id).First();
            dm.brands.Remove(a);
            dm.SaveChanges();
            dm.brands.Add(b);
            dm.SaveChanges();
            return RedirectToAction("AllBrands");
        }





        //shop
        public ActionResult Shop(string id)
        {
            var s = dm.shop_vendor.Single(x=>x.Shop_Id== id);


            return View(s);
        }
        public ActionResult AllShops()
        {
            List<shop_vendor> s = dm.shop_vendor.ToList();
            return View(s);
        }
        public ActionResult DeleteShop(string id)
        {
            var a = dm.shop_vendor.Where(d => d.Shop_Id == id).First();
            dm.shop_vendor.Remove(a);
            dm.SaveChanges();
            return RedirectToAction("AllShops");
        }
        public ActionResult UpdateShop(string id)
        {
            var s = dm.shop_vendor.Single(x=>x.Shop_Id==id);
            List<catagory> c = dm.catagories.ToList();
            ViewBag.catlist = c;


            ViewBag.cat = dm.catagories.Where(x => x.Cat_ID == s.Catagory).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult UpdateShop(shop_vendor s, HttpPostedFileBase Shop_Logo_File)
        {
            var a = dm.shop_vendor.Where(d => d.Shop_Id == s.Shop_Id).FirstOrDefault();
            dm.shop_vendor.Remove(a);
            dm.SaveChanges();


            var fileType = Path.GetExtension(Shop_Logo_File.FileName);
            if (Shop_Logo_File != null && Shop_Logo_File.ContentLength > 0)
            {

                var fileName = Path.GetFileName(Shop_Logo_File.FileName);
                fileName = s.Shop_Id + fileType;
                var path = Path.Combine(Server.MapPath("~/Libs/Store/images/Shop/"), fileName);
                Shop_Logo_File.SaveAs(path);

                s.Shop_Logo = "~/Libs/Store/images/Shop/" + fileName;
                dm.shop_vendor.Add(s);
                dm.SaveChanges();
            }


           
            return RedirectToAction("AllShops");
        }

        public ActionResult AddShop() {
            List<catagory> c = dm.catagories.ToList();
            ViewBag.catlist = c;
            return View();
        }
        [HttpPost]
        public ActionResult AddShop(shop_vendor sv, HttpPostedFileBase Shop_Logo_File)
        {
            List<catagory> c = dm.catagories.ToList();
            ViewBag.catlist = c;
            var fileType = Path.GetExtension(Shop_Logo_File.FileName);
            if (Shop_Logo_File != null && Shop_Logo_File.ContentLength > 0)
            {
               
                var fileName = Path.GetFileName(Shop_Logo_File.FileName);
                fileName = sv.Shop_Id+fileType;
                var path = Path.Combine(Server.MapPath("~/Libs/Store/images/Shop/"), fileName);
                Shop_Logo_File.SaveAs(path);

                sv.Shop_Logo = "~/Libs/Store/images/Shop/"+fileName;
            dm.shop_vendor.Add(sv);
            dm.SaveChanges();
            }


            return View();
        }

    }
}
