
using JsonSubTypes;
using Newtonsoft.Json;


namespace SlackAPI.Composition
{

    //https://api.slack.com/reference/messaging/block-elements

    public class ImageElement : IElement
    {
        public string Type { get; } = ElementTypes.Image;

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }
    }
    public class ButtonElement : IElement
    {
        public string Type { get; } = ElementTypes.Button;
        public TextObject Text { get; set; }

        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
        public string Style { get; set; } 
        public ConfirmObject Confirm { get; set; }
    }
    public class StaticSelectElement : IElement
    {
        public string Type { get; } = ElementTypes.StaticSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        public TextObject Placeholder { get; set; }
        public OptionObject[] Options { get; set; }

        [JsonProperty("option_groups")]
        public OptionGroupObject[] OptionGroups { get; set; }

        [JsonProperty("initial_option")]
        public string InitialOption { get; set; }

        public ConfirmObject Confirm { get; set; }
    }
    public class ExternalSelectElement : IElement
    {
        public string Type { get; } = ElementTypes.ExternalSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_option")]
        public string InitialOption { get; set; }

        [JsonProperty("min_query_length")]
        public int MinQueryLength { get; set; }


        public ConfirmObject Confirm { get; set; }
    }


    public class UserSelectElement : IElement
    {
        public string Type { get; } = ElementTypes.UserSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_user")]
        public string InitialUser { get; set; }
        public ConfirmObject Confirm { get; set; }
    }
    public class ConversationSelectElement : IElement
    {
        public string Type { get; } = ElementTypes.ChannelSelect;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }

        [JsonProperty("initial_conversation")]
        public string InitialConversation { get; set; }
        public ConfirmObject Confirm { get; set; }
    }
    public class ChannelSelectElement : IElement
    {
        public string Type { get; } = ElementTypes.ChannelSelect;
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public TextObject placeholder { get; set; }
        [JsonProperty("initial_channel")]
        public string InitialChannel { get; set; }
        public ConfirmObject Confirm { get; set; }
    }
    public class OverflowElement : IElement
    {
        public string Type { get; } = ElementTypes.Overflow;
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public OptionObject[] Options { get; set; }
        public ConfirmObject Confirm { get; set; }
    }

    public class DatePickerElement : IElement
    {
        public string Type { get; } = ElementTypes.DatePicker;

        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }
        [JsonProperty("initial_date")]
        public string InitialDate { get; set; }
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
        public virtual string Type { get; set; }
        public string Text { get; set; }
        public bool? Emoji { get; set; }
        public bool? Verbatim { get; set; }
    }

    public class PlainTextObject : TextObject
    {
        public override string Type { get; set; } = TextTypes.PlainText;
    }

    public class MarkdownTextObject : TextObject
    {
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