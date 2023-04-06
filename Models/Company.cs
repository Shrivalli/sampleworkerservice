using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sampleworkerservice.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("catchphrase")]
        public string? CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string? Bs { get; set; }
    }
}
