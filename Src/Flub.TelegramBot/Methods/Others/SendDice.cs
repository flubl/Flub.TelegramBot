using Flub.TelegramBot.Types;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send an animated emoji that will display a random value.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendDice : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Emoji on which the dice throw animation is based.
        /// Dice can have values 1-6 for <see cref="DiceType.Dice"/> “🎲”, <see cref="DiceType.BullsEye"/> “🎯” and <see cref="DiceType.Bowling"/> “🎳”,
        /// values 1-5 for <see cref="DiceType.Basketball"/> “🏀” and <see cref="DiceType.Football"/> “⚽”, and values 1-64 for <see cref="DiceType.SlotMachine"/> “🎰”.
        /// Defaults to <see cref="DiceType.Dice"/> “🎲”.
        /// </summary>
        [JsonPropertyName("emoji")]
        public DiceType? Emoji { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendDice"/> class.
        /// </summary>
        public SendDice() : base("sendDice") { }
    }

    public static class SendDiceExtension
    {
        private static Task<Message> SendDice(this TelegramBot bot, SendDice method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send an animated emoji that will display a random value.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="emoji">
        /// Emoji on which the dice throw animation is based.
        /// Dice can have values 1-6 for <see cref="DiceType.Dice"/> “🎲”, <see cref="DiceType.BullsEye"/> “🎯” and <see cref="DiceType.Bowling"/> “🎳”,
        /// values 1-5 for <see cref="DiceType.Basketball"/> “🏀” and <see cref="DiceType.Football"/> “⚽”, and values 1-64 for <see cref="DiceType.SlotMachine"/> “🎰”.
        /// Defaults to <see cref="DiceType.Dice"/> “🎲”.
        /// </param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendDice(this TelegramBot bot,
            string chatId,
            DiceType? emoji = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendDice(bot, new()
            {
                ChatId = chatId,
                Emoji = emoji,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send an animated emoji that will display a random value.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="emoji">
        /// Emoji on which the dice throw animation is based.
        /// Dice can have values 1-6 for <see cref="DiceType.Dice"/> “🎲”, <see cref="DiceType.BullsEye"/> “🎯” and <see cref="DiceType.Bowling"/> “🎳”,
        /// values 1-5 for <see cref="DiceType.Basketball"/> “🏀” and <see cref="DiceType.Football"/> “⚽”, and values 1-64 for <see cref="DiceType.SlotMachine"/> “🎰”.
        /// Defaults to <see cref="DiceType.Dice"/> “🎲”.
        /// </param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendDice(this TelegramBot bot,
            IChat chat,
            DiceType? emoji = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendDice(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Emoji = emoji,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
