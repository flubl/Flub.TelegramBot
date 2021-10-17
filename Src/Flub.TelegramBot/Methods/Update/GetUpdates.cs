using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to receive incoming updates using long polling (<see href="https://en.wikipedia.org/wiki/Push_technology#Long_polling">wiki</see>).
    /// An list of <see cref="Update"/> objects is returned.
    /// Notes:
    /// 1. This method will not work if an outgoing webhook is set up.
    /// 2. In order to avoid getting duplicate updates, recalculate offset after each server response.
    /// </summary>
    public class GetUpdates : Method<IEnumerable<Update>>
    {
        /// <summary>
        /// Identifier of the first update to be returned. Must be greater by one than the highest among the identifiers of previously received updates.
        /// By default, updates starting with the earliest unconfirmed update are returned.
        /// An update is considered confirmed as soon as <see cref="GetUpdates"/> is called with an offset higher than its <see cref="Update.Id"/>.
        /// The negative offset can be specified to retrieve updates starting from -offset update from the end of the updates queue.
        /// All previous updates will forgotten.
        /// </summary>
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        /// <summary>
        /// Limits the number of updates to be retrieved. Values between 1-100 are accepted. Defaults to 100.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }
        /// <summary>
        /// Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling.
        /// Should be positive, short polling should be used for testing purposes only.
        /// </summary>
        [JsonPropertyName("timeout")]
        public int? Timeout { get; set; }
        /// <summary>
        /// A list of the update types you want your bot to receive.
        /// Specify an empty list to receive all update types except <see cref="UpdateType.ChatMember"/> (default).
        /// If not specified, the previous setting will be used.
        /// Please note that this parameter doesn't affect updates created before the call to the <see cref="GetUpdates"/>,
        /// so unwanted updates may be received for a short period of time.
        /// </summary>
        [JsonPropertyName("allowed_updates")]
        public IEnumerable<UpdateType> AllowedUpdates { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUpdates"/> class.
        /// </summary>
        public GetUpdates() : base("getUpdates") { }
    }

    public static class GetUpdatesExtension
    {
        private static Task<IEnumerable<Update>> GetUpdates(this TelegramBot bot, GetUpdates method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to receive incoming updates using long polling (<see href="https://en.wikipedia.org/wiki/Push_technology#Long_polling">wiki</see>).
        /// An Array of <see cref="Update"/> objects is returned.
        /// Notes:
        /// 1. This method will not work if an outgoing webhook is set up.
        /// 2. In order to avoid getting duplicate updates, recalculate offset after each server response.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="offset">
        /// Identifier of the first update to be returned. Must be greater by one than the highest among the identifiers of previously received updates.
        /// By default, updates starting with the earliest unconfirmed update are returned.
        /// An update is considered confirmed as soon as <see cref="GetUpdates"/> is called with an offset higher than its <see cref="Update.Id"/>.
        /// The negative offset can be specified to retrieve updates starting from -offset update from the end of the updates queue.
        /// All previous updates will forgotten.
        /// </param>
        /// <param name="limit">Limits the number of updates to be retrieved. Values between 1-100 are accepted. Defaults to 100.</param>
        /// <param name="timeout">
        /// Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling.
        /// Should be positive, short polling should be used for testing purposes only.
        /// </param>
        /// <param name="allowedUpdates">
        /// A list of the update types you want your bot to receive.
        /// Specify an empty list to receive all update types except <see cref="UpdateType.ChatMember"/> (default).
        /// If not specified, the previous setting will be used.
        /// Please note that this parameter doesn't affect updates created before the call to the <see cref="GetUpdates"/>,
        /// so unwanted updates may be received for a short period of time.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<IEnumerable<Update>> GetUpdates(this TelegramBot bot,
            int? offset = null,
            int? limit = null,
            int? timeout = null,
            IEnumerable<UpdateType> allowedUpdates = null,
            CancellationToken cancellationToken = default) => GetUpdates(bot, new()
            {
                Offset = offset,
                Limit = limit,
                Timeout = timeout,
                AllowedUpdates = allowedUpdates
            }, cancellationToken);
    }
}
