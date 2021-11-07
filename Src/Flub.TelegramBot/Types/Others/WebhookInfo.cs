using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Contains information about the current status of a webhook.
    /// </summary>
    public class WebhookInfo
    {
        /// <summary>
        /// Webhook <see cref="Uri"/>, may be empty if webhook is not set up.
        /// </summary>
        [Required]
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// <see langword="true"/>, if a custom certificate was provided for webhook certificate checks.
        /// </summary>
        [Required]
        [JsonPropertyName("has_custom_certificate")]
        public bool? HasCustomCertificate { get; set; }
        /// <summary>
        /// Number of updates awaiting delivery.
        /// </summary>
        [Required]
        [JsonPropertyName("pending_update_count")]
        public int? PendingUpdateCount { get; set; }
        /// <summary>
        /// Optional. Currently used webhook IP address.
        /// </summary>
        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }
        /// <summary>
        /// Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook.
        /// </summary>
        [JsonPropertyName("last_error_date")]
        public long? LastErrorDateValue { get; set; }
        /// <summary>
        /// Optional. Date for the most recent error that happened when trying to deliver an update via webhook.
        /// </summary>
        [JsonIgnore]
        public DateTime? LastErrorDate
        {
            get => LastErrorDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(LastErrorDateValue.Value).DateTime : null;
            set => LastErrorDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook.
        /// </summary>
        [JsonPropertyName("last_error_message")]
        public string LastErrorMessage { get; set; }
        /// <summary>
        /// Optional. Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery.
        /// </summary>
        [JsonPropertyName("max_connections")]
        public int? MaxConnections { get; set; }
        /// <summary>
        /// Optional. A list of update types the bot is subscribed to. Defaults to all update types except <see cref="UpdateType.ChatMember"/>.
        /// </summary>
        [JsonPropertyName("allowed_updates")]
        public IEnumerable<UpdateType> AllowedUpdates { get; set; }

        public override string ToString() => $"{nameof(WebhookInfo)}[{Url}]";
    }
}
