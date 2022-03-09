using RestaurantRater116.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater116.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: /Restaurant
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var query = context.Restaurants.ToArray();
            return View(query);
        }

        // GET: /Restaurant/Create
        public ActionResult Create()
        {
            ViewData["Error"] = string.Empty;
            return View(new Restaurant());
        }
        // POST: /Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant model)
        {
            var context = new ApplicationDbContext();
            context.Restaurants.Add(model);
            if (context.SaveChanges() == 1)
            {
                return Redirect("/Restaurant");
            }
            // create object in db here
            ViewData["Error"] = "Couldn't create your restaurant. Sorry!";
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var context = new ApplicationDbContext();
            var entity = context.Restaurants.Find(id);
            if (entity != null)
            {
                return View(entity);
            }
            // Make a 404
            return Redirect("/restaurant");
        }

        public ActionResult Edit(int id)
        {
            ViewData["Error"] = string.Empty;
            var context = new ApplicationDbContext();
            var entity = context.Restaurants.Find(id);
            if (entity != null)
            {
                return View(entity);
            }
            // Make a 404
            return Redirect("/restaurant");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Restaurant model)
        {
            if (model.RestaurantId != id)
            {
                return Redirect("/restaurant");
            }
            var context = new ApplicationDbContext();
            var entity = context.Restaurants.Find(model.RestaurantId);
            entity.Name = model.Name;
            entity.Rating = model.Rating;
            if (context.SaveChanges() == 1)
            {
                return Redirect("/restaurant");
            }
            ViewData["Error"] = "Couldn't edit your restaurant, sorry!";
            return View(model);
        }
    }
}