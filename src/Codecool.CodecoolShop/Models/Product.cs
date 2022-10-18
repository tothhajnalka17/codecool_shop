using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("defaultPrice")]
        public string DefaultPrice { get; set; }

        [JsonProperty("productCategory")]
        public string ProductCategory { get; set; }
        
        [JsonProperty("supplier")]
        public string Supplier { get; set; }

    }
}
