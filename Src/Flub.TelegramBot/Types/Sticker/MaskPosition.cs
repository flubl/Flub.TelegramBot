using Flub.Utils.Json;
using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object describes the position on faces where a mask should be placed by default.
    /// </summary>
    public class MaskPosition
    {
        /// <summary>
        /// The part of the face relative to which the mask should be placed.
        /// </summary>
        [JsonPropertyName("point")]
        public MaskPositionType Point { get; set; }
        /// <summary>
        /// Shift by X-axis measured in widths of the mask scaled to the face size, from left to right.
        /// For example, choosing -1.0 will place mask just to the left of the default mask position.
        /// </summary>
        [JsonPropertyName("x_shift")]
        public float XShift { get; set; }
        /// <summary>
        /// Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom.
        /// For example, 1.0 will place the mask just below the default mask position.
        /// </summary>
        [JsonPropertyName("y_shift")]
        public float YShift { get; set; }
        /// <summary>
        /// Shift by X-axis and Y-axis measured in widths and heights of the mask scaled to the face size, from left to right and from top to bottom.
        /// </summary>
        [JsonIgnore]
        public PointF Shift
        {
            get => new(XShift, YShift);
            set => (XShift, YShift) = (value.X, value.Y);
        }
        /// <summary>
        /// Mask scaling coefficient. For example, 2.0 means double size.
        /// </summary>
        [JsonPropertyName("scale")]
        public float Scale { get; set; }

        public override string ToString() => $"{nameof(MaskPosition)}[{Point}, {Shift}, {Scale}]";
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum MaskPositionType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("forehead")]
        Forehead = 0x1,
        [JsonFieldValue("eyes")]
        Eyes = 0x2,
        [JsonFieldValue("mouth")]
        Mouth = 0x4,
        [JsonFieldValue("chin")]
        Chin = 0x8
    }
}
