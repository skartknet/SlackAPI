using Newtonsoft.Json;

namespace SlackAPI.Interactive
{
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }
    }
}
