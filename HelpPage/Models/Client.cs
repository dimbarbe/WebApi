using Newtonsoft.Json;

namespace HelpPage.Models
{
    public class Client
    {
        [JsonProperty(PropertyName = "Id")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Apellido")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Ciudad")]
        public string City { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}