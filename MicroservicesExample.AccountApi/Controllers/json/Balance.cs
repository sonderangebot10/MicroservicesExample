using Newtonsoft.Json;

namespace MicroservicesExample.Controllers.json
{
    [JsonObject]
    public class Balance
    {
        [JsonProperty]
        public double amount { get; set;  }
    }
}
