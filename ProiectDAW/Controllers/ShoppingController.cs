using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class ShoppingController : Controller
    {
        private ShoppingDBContext db = new ShoppingDBContext();

        // GET: Student
        public ActionResult Index()
        {
            var shoppings = from shopping in db.Shoppings
                           orderby shopping.Id descending
                           select shopping;
            ViewBag.Shoppings = shoppings;

            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }

            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Shopping shopping)
        {
            try
            {
                db.Shoppings.Add(shopping);
                db.SaveChanges();//commit to database
                return RedirectToAction("Index");
            }catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Shopping shopping = db.Shoppings.Find(id);
            ViewBag.Shoppings = shopping;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Shopping requestShopping)
        {
            try
            {
                Shopping shopping = db.Shoppings.Find(id);
                if (TryUpdateModel(shopping))
                {
                    shopping.Price = requestShopping.Price;
                    shopping.Date = requestShopping.Date;
                    shopping.Basket = requestShopping.Basket;

                    db.SaveChanges(); //commit to database
                }
                return RedirectToAction("Index");
            } catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Shopping shopping = db.Shoppings.Find(id);

            TempData["message"] = "Cumparaturile din ziua " + shopping.Date + " a fost sterse.";

            db.Shoppings.Remove(shopping);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}