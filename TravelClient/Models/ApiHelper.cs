using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"reviews", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}