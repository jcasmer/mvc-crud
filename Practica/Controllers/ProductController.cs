using Practica.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Models;
using System.Net;
using System.Data.Entity;

namespace Practica.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext db = new StoreContext();
        //
        // GET: /Product/
        public ActionResult Index()
        {

            return View(db.Product.ToList());
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Product.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        //
        // GET: /Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(Products product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        //
        // GET: /Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Product.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        //
        // GET: /Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Product.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Products product)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    product = db.Product.Find(id);
                    if (product == null)
                    {
                        return HttpNotFound();
                    } 
                    db.Product.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
    }
}
