using System;

namespace httpTest
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://api.icndb.com/jokes/random?limitTo=[nerdy] ");
                response.EnsureSuccessStatusCode();
                HttpResponseMessage r = await client.GetAsync("http://api.icndb.com/jokes/random?exclude=Array");
                r.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string rbody = await r.Content.ReadAsStringAsync();
                System.Console.WriteLine(rbody);
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ",e.Message);
            }
        }
    }
}
