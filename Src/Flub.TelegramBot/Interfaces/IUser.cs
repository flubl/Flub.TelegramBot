namespace Flub.TelegramBot
{
    /// <summary>
    /// Contains basic information for a user.
    /// </summary>
    public interface IUser : IChat
    {
        /// <summary>
        /// Optional. First name.
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Optional. Last name.
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Optional. Username.
        /// </summary>
        string Username { get; }
    }
}
