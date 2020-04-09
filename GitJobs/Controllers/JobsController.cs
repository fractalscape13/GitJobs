using Microsoft.AspNetCore.Mvc;
using GitJobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

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

    [Authorize]
    public IActionResult Create(string title1, string location1, string url1)
    {
      ViewBag.Tit = title1;
      ViewBag.Location = location1;
      ViewBag.Url = url1;
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(string loc, string tit, string ur, string sta, int pri)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Job newJob = new Job(loc, tit, ur, sta, pri);
      newJob.User = currentUser;
      _db.Jobs.Add(newJob);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public IActionResult Search(string location, string title)
    {
      var searchResults = Job.Search(location, title);
      return View("Index", searchResults);
    }
  }
}