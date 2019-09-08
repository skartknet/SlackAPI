
using JsonSubTypes;
using Newtonsoft.Json;


namespace SlackAPI.Composition
{

    //https://api.slack.com/reference/messaging/block-elements

    public class ImageElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.Image;

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }
    }
    public class ButtonElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.Button;

        [JsonProperty("text")]
        public TextObject Text { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }
    public class StaticSelectElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.StaticSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject Placeholder { get; set; }

        [JsonProperty("options")]
        public OptionObject[] Options { get; set; }

        [JsonProperty("option_groups")]
        public OptionGroupObject[] OptionGroups { get; set; }

        [JsonProperty("initial_option")]
        public string InitialOption { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }
    public class ExternalSelectElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.ExternalSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_option")]
        public string InitialOption { get; set; }

        [JsonProperty("min_query_length")]
        public int MinQueryLength { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }


    public class UserSelectElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.UserSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_user")]
        public string InitialUser { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }
    public class ConversationSelectElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.ChannelSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_conversation")]
        public string InitialConversation { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }
    public class ChannelSelectElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.ChannelSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject placeholder { get; set; }

        [JsonProperty("initial_channel")]
        public string InitialChannel { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }
    public class OverflowElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.Overflow;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("options")]
        public OptionObject[] Options { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }

    public class DatePickerElement : IElement
    {
        [JsonProperty("type")]
        public string Type { get; } = ElementTypes.DatePicker;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        [JsonProperty("placeholder")]
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_date")]
        public string InitialDate { get; set; }

        [JsonProperty("confirm")]
        public ConfirmObject Confirm { get; set; }
    }



    public static class ElementTypes
    {
        public const string Image = "image";
        public const string Button = "button";
        public const string StaticSelect = "static_select";
        public const string ExternalSelect = "external_select";
        public const string UserSelect = "user_select";
        public const string ChannelSelect = "channel_select";
        public const string ConversationSelect = "conversation_select";
        public const string Overflow = "overflow";
        public const string DatePicker = "datepicker";
    }


    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(PlainTextObject), TextTypes.PlainText)]
    [JsonSubtypes.KnownSubType(typeof(MarkdownTextObject), TextTypes.Markdown)]

    public abstract class TextObject : IElement
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("emoji")]
        public bool? Emoji { get; set; }

        [JsonProperty("verbatim")]
        public bool? Verbatim { get; set; }
    }

    public class PlainTextObject : TextObject
    {
        [JsonProperty("type")]
        public override string Type { get; set; } = TextTypes.PlainText;
    }

    public class MarkdownTextObject : TextObject
    {
        [JsonProperty("type")]
        public override string Type { get; set; } = TextTypes.Markdown;
    }

    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(ImageElement), ElementTypes.Image)]
    [JsonSubtypes.KnownSubType(typeof(ButtonElement), ElementTypes.Button)]
    [JsonSubtypes.KnownSubType(typeof(StaticSelectElement), ElementTypes.StaticSelect)]
    [JsonSubtypes.KnownSubType(typeof(ExternalSelectElement), ElementTypes.ExternalSelect)]
    [JsonSubtypes.KnownSubType(typeof(UserSelectElement), ElementTypes.UserSelect)]
    [JsonSubtypes.KnownSubType(typeof(ConversationSelectElement), ElementTypes.ConversationSelect)]
    [JsonSubtypes.KnownSubType(typeof(OverflowElement), ElementTypes.Overflow)]
    [JsonSubtypes.KnownSubType(typeof(DatePickerElement), ElementTypes.DatePicker)]
    [JsonSubtypes.KnownSubType(typeof(PlainTextObject), TextTypes.PlainText)]
    [JsonSubtypes.KnownSubType(typeof(MarkdownTextObject), TextTypes.Markdown)]
    public interface IElement
    {
        string Type { get; }
    }
}