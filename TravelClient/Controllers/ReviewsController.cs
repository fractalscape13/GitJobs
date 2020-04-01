using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetAll();
      return View(allReviews);
    }

    [HttpPost]
    public IActionResult Index(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

    public IActionResult Search(string country, string city, string destination)
    {
      var searchResults = Review.Search(country, city, destination);
      return View("Index", searchResults);
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    public IActionResult Edit(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Details(int id, Review review)
    {
      review.ReviewId = id;
      Review.Put(review);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      return RedirectToAction("Index");
    }
  }
}