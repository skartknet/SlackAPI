using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAPI.Composition
{
    // https://api.slack.com/reference/messaging/composition-objects#option-group

   

    public class OptionObject
    {
        [JsonProperty("text")]
        public TextObject Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class OptionGroupObject
    {
        [JsonProperty("label")]
        public TextObject Label { get; set; }

        [JsonProperty("options")]
        public OptionObject[] Options { get; set; }
    }

    public class ConfirmObject
    {
        [JsonProperty("title")]
        public TextObject Title { get; set; }

        [JsonProperty("text")]
        public TextObject Text { get; set; }

        [JsonProperty("confirm")]
        public TextObject Confirm { get; set; }

        [JsonProperty("deny")]
        public TextObject Deny { get; set; }
    }

    public static class TextTypes
    {
        public const string Markdown = "mrkdwn";
        public const string PlainText = "plain_text";
    }
}
