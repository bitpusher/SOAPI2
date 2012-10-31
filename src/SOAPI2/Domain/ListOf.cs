using Newtonsoft.Json;

namespace SOAPI2.Domain
{
    public class ListOf<T> where T:class,new()
    {
        [JsonProperty("backoff")]
        public int Backoff { get; set; }

        [JsonProperty("error_id")]
        public int ErrorId { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_name")]
        public string ErrorName { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("items")]
        public T[] Items { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("quota_max")]
        public int QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public int QuotaRemaining { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}