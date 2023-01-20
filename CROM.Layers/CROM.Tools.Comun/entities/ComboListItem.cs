namespace CROM.Tools.Comun.entities
{
    using Newtonsoft.Json;

    public class ComboListItem
    {
        public ComboListItem()
        {
            text = string.Empty;
            value = 0;
        }

        [JsonProperty("text")]
        public string   text { get; set; }

        [JsonProperty("value")]
        public int value { get; set; }

    }

    public class ComboListItemString
    {
        public ComboListItemString()
        {
            text = string.Empty;
            value = string.Empty;
        }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

    }

    public class AutocompleteItemString
    {
        public AutocompleteItemString()
        {
            Name = string.Empty;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class BodyListItem
    {
        public BodyListItem()
        {
            key = string.Empty;
            value = string.Empty;
            type = string.Empty; 
        }

        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

}
