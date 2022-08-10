// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace ChuckNorrisJokes
{
    class Program
    {
        // Create an httpclient object to connect to the URI
        private static readonly HttpClient client = new HttpClient();
    
        // Create a method to get data from the server and process the JSON file
        // use the async modifier to make sure the processes can work asynchronously
        // return a Task object (like a JS promise?) that promises to return a Joke object
        private static async Task<Joke> ProcessJokes(string URI)
        {
            // Get the stream of data asynchronously from the server
            var streamTask = client.GetStreamAsync(URI);
            // Use the JSON deserializer to turn the JSON string into a C# Joke Object
            var APIData = await JsonSerializer.DeserializeAsync<Joke>(await streamTask);
    
            return APIData;
        }

        // Print the Joke object
        private static void PrintJokes(Joke JokeData)
        {
            Console.WriteLine(JokeData.Type);

            foreach (Value value in JokeData.Values)
            {
                Console.Write($"id: {value.JokeID} ");
                
                Console.Write("categories: ");
                if (value.Categories.Count() > 0)
                {
                    foreach (string category in value.Categories)
                    Console.WriteLine(category + " ");

                } else 
                {
                    Console.WriteLine("none");
                }

                Console.WriteLine($"joke: {value.Joke}");
            }
        }

        static async Task Main(string[] args)
        {
            string FiveJokesURI = "http://api.icndb.com/jokes/random/5";
            Joke FiveJokes = await ProcessJokes(FiveJokesURI);
            PrintJokes(FiveJokes);

            // string NerdyJokesURI = "http://api.icndb.com/jokes/random?limitTo=[nerdy]";
            // Joke NerdyJokes = await ProcessJokes(NerdyJokesURI);
            // PrintJokes(NerdyJokesURI);
        }
    }
}