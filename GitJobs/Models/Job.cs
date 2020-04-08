using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GitJobs.Models
{
  public class Job
  {
    public int JobId { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Status { get; set; }
    public int Priority { get; set; }
    public ApplicationUser User { get; set; }
    
    public Job(string description, string location, string title, string url, string status, int priority)
    {
      this.Description = description;
      this.Location = location;
      this.Title = title;
      this.Url = url;
      this.Status = status;
      this.Priority = priority;
    }


    public static List<Job> GetAll()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Job> jobList = JsonConvert.DeserializeObject<List<Job>>(jsonResponse.ToString());

      return jobList;
    }

    public static List<Job> Search(string description, string location, string title)
    {
      var apiCallTask = ApiHelper.Search(description, location, title);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Job> jobList = JsonConvert.DeserializeObject<List<Job>>(jsonResponse.ToString());

      return jobList;
    }

    public static Job GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse =JsonConvert.DeserializeObject<JObject>(result);
      Job job = JsonConvert.DeserializeObject<Job>(jsonResponse.ToString());

      return job;
    }
  }
}