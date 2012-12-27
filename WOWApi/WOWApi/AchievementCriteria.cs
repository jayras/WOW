using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WOWApi
{
    public class AchievementCriteria
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("orderIndex")]
        public int OrderIndex { get; set; }
    }
}
