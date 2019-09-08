using JsonSubTypes;
using Newtonsoft.Json;
using SlackAPI.Composition;

namespace SlackAPI.Interactive
{

    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(ButtonElementInteractive), ElementTypes.Button)]
    [JsonSubtypes.KnownSubType(typeof(StaticSelectElementInteractive), ElementTypes.StaticSelect)]
    [JsonSubtypes.KnownSubType(typeof(ExternalSelectElementInteractive), ElementTypes.ExternalSelect)]
    [JsonSubtypes.KnownSubType(typeof(UserSelectElementInteractive), ElementTypes.UserSelect)]
    [JsonSubtypes.KnownSubType(typeof(ConversationSelectElementInteractive), ElementTypes.ConversationSelect)]
    [JsonSubtypes.KnownSubType(typeof(OverflowElementInteractive), ElementTypes.Overflow)]
    [JsonSubtypes.KnownSubType(typeof(DatePickerElementInteractive), ElementTypes.DatePicker)]
    public interface IInteractiveElement
    {
        string ActionId { get; set; }
        string BlockId { get; set; }

        string Value { get; set; }

    }


    public class ButtonElementInteractive : ButtonElement, IInteractiveElement
    {
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

    }

    public class DatePickerElementInteractive : DatePickerElement, IInteractiveElement
    {

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_date")]
        public string Value { get; set; }
    }


    public class StaticSelectElementInteractive : StaticSelectElement, IInteractiveElement
    {

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_option")]
        public OptionObject SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.Value;
            }
            set { }
        }

    }
    public class ExternalSelectElementInteractive : ExternalSelectElement, IInteractiveElement
    {


        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        [JsonProperty("selected_option")]
        public OptionObject SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.Value;
            }
            set { }
        }
    }


    public class UserSelectElementInteractive : UserSelectElement, IInteractiveElement
    {


        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_user")]
        public string Value { get; set; }
    }
    public class ConversationSelectElementInteractive : ConversationSelectElement, IInteractiveElement
    {


        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_conversation")]
        public string Value { get; set; }
    }
    public class ChannelSelectElementInteractive : ChannelSelectElement, IInteractiveElement
    {


        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_channel")]
        public string Value { get; set; }
    }
    public class OverflowElementInteractive : OverflowElement, IInteractiveElement
    {
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("selected_option")]
        public OptionObject SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.Value;
            }
            set { }
        }
    }
}
