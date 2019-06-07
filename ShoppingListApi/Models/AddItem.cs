using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi
{
    public class AddItem
    {
        [Required]
        [JsonProperty(PropertyName = "item")]
        public string Item { get; set; }
    }
}
