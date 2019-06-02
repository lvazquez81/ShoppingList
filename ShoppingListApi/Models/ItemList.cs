using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShoppingListApi
{
    public class ItemList
    {
        [JsonProperty(PropertyName = "items")]
        public IList<string> Items { get; set; }
    }
}
