namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an animation file (GIF or H.264/MPEG-4 AVC video without sound).
    /// </summary>
    public class Animation : Video
    {
        public override string ToString() => $"{nameof(Animation)}[{Width}x{Height}, {Duration}s, {Id}]";
    }
}
