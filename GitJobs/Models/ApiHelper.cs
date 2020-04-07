using System.Threading.Tasks;
using RestSharp;

namespace GitJobs.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest(Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Search(string description, string location, string title)
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest($"?description={description}&location={location}&title={title}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest($"jobs/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    // do we need to add a header for authorization to the following three methods?? 
    public static async Task Post(string newReview)
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest($"jobs", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newReview)
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest($"jobs/{id}",Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://jobs.github.com/positions.json");
      RestRequest request = new RestRequest($"jobs/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}