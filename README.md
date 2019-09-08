# SlackAPI Reimagined

This is a fork form the Inumedia's Slack API implementation: https://github.com/Inumedia/SlackAPI

When working with that implementation I found mnay things to fix or I didn't like. Instead of creating a million of PRs I decided to create my own fork. 

You're free to use this on your own risk, open any PRs if you like or give me some feedback.


## Changes over the original Inumedia version (go there to learn more about what the Slack API can do.)
- Added Interactive message
- Added JsonSubTypes to serialize and deserialize to the right subtypes instead bloated Block or Element buckets.
- Follows .NET naming conventions for parameters and uses JsonProperty to map them