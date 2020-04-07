using Microsoft.AspNetCore.Mvc;
using GitJobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace GitJobs.Controllers
{
  [Authorize]
  public class JobsController : Controller
  {
    private readonly GitJobsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public JobsController(UserManager<ApplicationUser> userManager, GitJobsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
      var allJobs = Job.GetAll();
      return View(allJobs);
    }

    // public IActionResult Create()
    // {
       
    //   return View();
    // }

    [HttpPost]
    public async Task<ActionResult> Create(string desc, string loc, string tit, string ur)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Job newJob = new Job(desc, loc, tit, ur);
      newJob.User = currentUser;
      _db.Jobs.Add(newJob);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

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

    // [HttpPost]
    // public ActionResult Search(string search)
    // {
    //   List<Job> model = _db.Jobs.Where(job => (job.Description.Contains(search)) || (job.Title.Contains(search)) || (job.Location.Contains(search))).ToList();
    //   ViewBag.Model = model;
    //   return RedirectToAction("Index");
    // }

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