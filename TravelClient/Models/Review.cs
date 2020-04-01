using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace TravelClient.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Author { get; set; }
    public string Destination { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public static List<Review> GetAll()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    }

    
  }
}