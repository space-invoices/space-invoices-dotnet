﻿using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDefault
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
