using System;
using Newtonsoft.Json;
using SlackAPI;

namespace SlackAPI.Interactive
{
    public interface IInteractiveElement
    {

        string action_id { get; set; }

        string BlockId { get; set; }

        string Value { get; set; }

    }


    public class ButtonElementInteractive : ButtonElement, IInteractiveElement
    {
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
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
        public Option SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.value;
            }
            set { }
        }

    }
    public class ExternalSelectElementInteractive : ExternalSelectElement, IInteractiveElement
    {


        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        [JsonProperty("selected_option")]
        public Option SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.value;
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
        public Option SelectedOption { get; set; }

        public string Value
        {
            get
            {
                return SelectedOption.value;
            }
            set { }
        }
    }
}
