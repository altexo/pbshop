using Newtonsoft.Json;

namespace pbshop_web.Models
{
    public class NotificationModel
    {

        public class DataPayload
    {
        // Add your custom properties as needed
        [JsonProperty("message")]
        public string Message { get; set; } = "Hi";
    }

    [JsonProperty("priority")]
    public string Priority { get; set; } = "high";

    [JsonProperty("data")]
    public DataPayload Data { get; set; }
    

    }
}