﻿using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Monday.com tags are objects that help you group items from different groups or different boards throughout your
    ///     account by a consistent keyword. Tag entities are created and presented through the “Tags” column.
    /// </summary>
    public class Tag
    {
        /// <summary>
        ///     The tag's unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public ulong Id { get; set; }

        /// <summary>
        ///     The tag's name.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        ///     The tag's color.
        /// </summary>
        [JsonProperty("color")]
        public string? Color { get; set; }
    }
}
