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
        private static readonly HttpClient client = new HttpClient();
    
        private static async Task<Joke> ProcessJokes()
        {
            var streamTask = client.GetStreamAsync("http://api.icndb.com/jokes/random/5");
            var APIData = await JsonSerializer.DeserializeAsync<Joke>(await streamTask);
            return APIData;
        }

        static async Task Main(string[] args)
        {
            Joke jokeData = await ProcessJokes();

            Console.WriteLine(jokeData.Type);

            foreach (Value joke in jokeData.Values)
            {
                Console.Write($"id: {joke.JokeID} ");
                
                Console.Write("categories: ");
                if (joke.Categories.Count() > 0)
                {
                    foreach (string category in joke.Categories)
                    Console.WriteLine(category + " ");

                } else 
                {
                    Console.WriteLine("none");
                }

                Console.WriteLine($"joke: {joke.Joke}");
            }
        }
    }
}