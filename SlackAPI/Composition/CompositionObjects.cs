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
        public TextObject Text { get; set; }
        public string Value { get; set; }
    }

    public class OptionGroupObject
    {
        public TextObject Label { get; set; }
        public OptionObject[] Options { get; set; }
    }

    public class ConfirmObject
    {
        public TextObject Title { get; set; }
        public TextObject Text { get; set; }
        public TextObject Confirm { get; set; }
        public TextObject Deny { get; set; }
    }

    public static class TextTypes
    {
        public const string Markdown = "mrkdwn";
        public const string PlainText = "plain_text";
    }
}
