using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get a list of profile pictures for a user.
    /// Returns a <see cref="UserProfilePhotos"/> object.
    /// </summary>
    public class GetUserProfilePhotos : Method<UserProfilePhotos>
    {
        /// <summary>
        /// Unique identifier of the target user.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Sequential number of the first photo to be returned. By default, all photos are returned.
        /// </summary>
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        /// <summary>
        /// Limits the number of photos to be retrieved. Values between 1-100 are accepted. Defaults to 100.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserProfilePhotos"/> class.
        /// </summary>
        public GetUserProfilePhotos() : base("getUserProfilePhotos") { }
    }

    public static class GetUserProfilePhotosExtension
    {
        private static Task<UserProfilePhotos> GetUserProfilePhotos(this TelegramBot bot, GetUserProfilePhotos method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get a list of profile pictures for a user.
        /// Returns a <see cref="UserProfilePhotos"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="offset">Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Limits the number of photos to be retrieved. Values between 1-100 are accepted. Defaults to 100.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<UserProfilePhotos> GetUserProfilePhotos(this TelegramBot bot,
            long? userId,
            int? offset = null,
            int? limit = null,
            CancellationToken cancellationToken = default) =>
            GetUserProfilePhotos(bot, new()
            {
                UserId = userId,
                Offset = offset,
                Limit = limit
            }, cancellationToken);

        /// <summary>
        /// Use this method to get a list of profile pictures for a user.
        /// Returns a <see cref="UserProfilePhotos"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Target user.</param>
        /// <param name="offset">Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Limits the number of photos to be retrieved. Values between 1-100 are accepted. Defaults to 100.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<UserProfilePhotos> GetUserProfilePhotos(this TelegramBot bot,
            IUser user,
            int? offset = null,
            int? limit = null,
            CancellationToken cancellationToken = default) =>
            GetUserProfilePhotos(bot, new()
            {
                UserId = user?.Id,
                Offset = offset,
                Limit = limit
            }, cancellationToken);
    }
}
