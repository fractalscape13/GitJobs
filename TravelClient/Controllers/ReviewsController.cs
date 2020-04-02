using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelClient.Controllers
{
  [Authorize]
  public class ReviewsController : Controller
  {
    [AllowAnonymous]
    public IActionResult Index()
    {
      var allReviews = Review.GetAll();
      return View(allReviews);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public IActionResult Search(string country, string city, string destination)
    {
      var searchResults = Review.Search(country, city, destination);
      return View("Index", searchResults);
    }

    [AllowAnonymous]
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