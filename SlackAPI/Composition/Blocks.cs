using JsonSubTypes;
using Newtonsoft.Json;

namespace SlackAPI.Composition

{
    //see https://api.slack.com/reference/messaging/blocks
    public class SectionBlock : IBlock
    {
        public string Type { get; } = BlockTypes.Section;

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        public TextObject Text { get; set; }
        public IElement Accessory { get; set; }
        public TextObject[] Fields { get; set; }
    }
    public class DividerBlock : IBlock
    {
        public string Type { get; } = BlockTypes.Divider;

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

    }
    public class ImageBlock : IBlock
    {
        public string Type { get; } = BlockTypes.Image;

        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        public TextObject Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }
    }
    public class ActionsBlock : IBlock
    {
        public string Type { get; } = BlockTypes.Actions;

        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        public IElement[] Elements { get; set; }
    }

    public static class ButtonStyles
    {
        public const string Primary = "primary";
        public const string Danger = "danger";
    }

    public static class BlockTypes
    {
        public const string Section = "section";
        public const string Divider = "divider";
        public const string Actions = "actions";
        public const string Context = "context";
        public const string Image = "image";
    }

    public class ContextBlock : IBlock
    {
        public string Type { get; } = BlockTypes.Context;

        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        public IElement[] Elements { get; set; }
    }


    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(SectionBlock), BlockTypes.Section)]
    [JsonSubtypes.KnownSubType(typeof(DividerBlock), BlockTypes.Divider)]
    [JsonSubtypes.KnownSubType(typeof(ActionsBlock), BlockTypes.Actions)]
    [JsonSubtypes.KnownSubType(typeof(ContextBlock), BlockTypes.Context)]
    [JsonSubtypes.KnownSubType(typeof(ImageBlock), BlockTypes.Image)]
    public interface IBlock
    {
        string Type { get; }
        string BlockId { get; set; }
    }

}
