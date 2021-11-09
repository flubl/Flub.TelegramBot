﻿using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an invite link for a chat.
    /// </summary>
    public class ChatInviteLink
    {
        /// <summary>
        /// The invite link. If the link was created by another chat administrator, then the second part of the link will be replaced with "...".
        /// </summary>
        [JsonPropertyName("invite_link")]
        public Uri InviteLink { get; set; }
        /// <summary>
        /// Creator of the link.
        /// </summary>
        [JsonPropertyName("creator")]
        public User Creator { get; set; }
        /// <summary>
        /// <see langword="true"/>, if users joining the chat via the link need to be approved by chat administrators.
        /// </summary>
        [JsonPropertyName("creates_join_request")]
        public bool? CreatesJoinRequest { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the link is primary.
        /// </summary>
        [JsonPropertyName("is_primary")]
        public bool? IsPrimary { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the link is revoked.
        /// </summary>
        [JsonPropertyName("is_revoked")]
        public bool? IsRevoked { get; set; }
        /// <summary>
        /// Optional. Invite link name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Optional. Point in time (Unix timestamp) when the link will expire or has been expired.
        /// </summary>
        [JsonPropertyName("expire_date")]
        public long? ExpireDateValue { get; set; }
        /// <summary>
        /// Optional. Point in time when the link will expire or has been expired.
        /// </summary>
        [JsonIgnore]
        public DateTime? ExpireDate
        {
            get => ExpireDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(ExpireDateValue.Value).DateTime : null;
            set => ExpireDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Optional. Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.
        /// </summary>
        [JsonPropertyName("member_limit")]
        public int? MemberLimit { get; set; }
        /// <summary>
        /// Optional. Number of pending join requests created using this link.
        /// </summary>
        [JsonPropertyName("pending_join_request_count")]
        public int? PendingJoinRequestCount { get; set; }

        public override string ToString() => $"{nameof(ChatInviteLink)}[{InviteLink}]";
    }
}
