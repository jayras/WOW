using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WOWApi
{
    public class AchievementRewardItems
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("tooltipParams")]
        public string ToolTipParams { get; set; }
    }
}
