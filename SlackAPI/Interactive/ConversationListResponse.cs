// <copyright file="ConversationListResult.cs" company="Mario Lopez">
// Copyright (c) 2019 Mario Lopez.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace SlackAPI.Interactive
{
    [RequestPath("conversations.list")]

    public class ConversationListResponse : Response
    {
        public Channel[] channels;
    }
}
