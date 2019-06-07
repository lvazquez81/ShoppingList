﻿using Newtonsoft.Json;

namespace ShoppingListApi
{
    public class MyItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "item")]
        public string Item { get; set; }
    }
}
