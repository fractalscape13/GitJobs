using Microsoft.AspNetCore.Mvc;
using GitJobs.Models;
using Microsoft.AspNetCore.Authorization;

namespace GitJobs.Controllers
{
  [Authorize]
  public class JobsController : Controller
  {
    [AllowAnonymous]
    public IActionResult Index()
    {
      var allJobs = Job.GetAll();
      return View(allJobs);
    }

    public IActionResult Create()
    {
      return View();
    }

    // [HttpPost]
    // public IActionResult Create(Job job)
    // {
    //   Job.Post(job);
    //   return RedirectToAction("Index");
    // }

    [AllowAnonymous]
    public IActionResult Search(string description, string location, string title)
    {
      var searchResults = Job.Search(description, location, title);
      return View("Index", searchResults);
    }

    [AllowAnonymous]
    public IActionResult Details(int id)
    {
      var job = Job.GetDetails(id);
      return View(job);
    }

    // public IActionResult Edit(int id)
    // {
    //   var job = Job.GetDetails(id);
    //   return View(job);
    // }

    // [HttpPost]
    // public IActionResult Details(int id, Job job)
    // {
    //   job.JobId = id;
    //   Job.Put(job);
    //   return RedirectToAction("Details", id);
    // }

    // public IActionResult Delete(int id)
    // {
    //   Job.Delete(id);
    //   return RedirectToAction("Index");
    // }
  }
}