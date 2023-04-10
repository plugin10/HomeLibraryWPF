using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Content.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("borrower")]
        public string? Borrower { get; set; }
    }
}
