﻿using System;

namespace Rystem.OpenAi.Chat
{
    public interface IOpenAiChat
    {
        /// <summary>
        /// Given a chat conversation, the model will return a chat completion response.
        /// </summary>
        /// <param name="message">The messages to generate chat completions for, in the chat format.</param>
        /// <returns>Builder</returns>
        ChatRequestBuilder Request(ChatMessage message);
    }
    [Obsolete("In version 3.x we'll remove IOpenAiChatApi and we'll use only IOpenAiChat to retrieve services")]
    public interface IOpenAiChatApi : IOpenAiChat
    {
    }
}