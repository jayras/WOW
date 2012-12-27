using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WOWApi
{
    public class AchievementAPI
    {
        [JsonProperty("accountWide")]
        public bool AccountWide { get; set; }

        [JsonProperty("criteria")]
        public List<AchievementCriteria> Criteria { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("reward")]
        public string Reward { get; set; }

        [JsonProperty("rewardItems")]
        public List<AchievementRewardItems> RewardItems { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
