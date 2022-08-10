using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ChuckNorrisJokes
{
    public class Value
    {
        [JsonPropertyName("id")]
        public int JokeID { get; set; }
        [JsonPropertyName("joke")]
        public string Joke { get; set; }
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }
    }
}