using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GitJobs.Models;
using System.Threading.Tasks;
using GitJobs.ViewModels;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace GitJobs.Controllers
{
  public class AccountController : Controller
  {
    private readonly GitJobsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GitJobsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(model.UserName) || String.IsNullOrWhiteSpace(model.Password))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          var user = new ApplicationUser { UserName = model.UserName };
          IdentityResult result = await _userManager.CreateAsync(user, model.Password);
          if (result.Succeeded)
          {
            return RedirectToAction("Login");
          }
          else
          {
            return View();
          }
        }
      }
      catch (Exception ex)
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      try
      {
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          return View();
        }
      }
      catch (Exception ex)
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> SavedJobs()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<Job> jobList = _db.Jobs.Where(job => job.User == currentUser).ToList();
      List<Job> model = jobList.OrderBy(x => x.Priority).ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
      return View(thisJob);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int jobId)
    {
      var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == jobId);
      _db.Jobs.Remove(thisJob);
      _db.SaveChanges();
      return RedirectToAction("SavedJobs");
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
      return View(thisJob);
    }

    [HttpPost]
    public ActionResult Edit(Job job)
    {
      _db.Entry(job).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("SavedJobs");
    }
  }
}