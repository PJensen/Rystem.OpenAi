﻿using System.Collections.Generic;
using System.Net.Http;
using Rystem.OpenAi.Audio;
using Rystem.OpenAi.Chat;
using Rystem.OpenAi.Completion;
using Rystem.OpenAi.Edit;
using Rystem.OpenAi.Embedding;
using Rystem.OpenAi.Files;
using Rystem.OpenAi.FineTune;
using Rystem.OpenAi.Image;
using Rystem.OpenAi.Management;
using Rystem.OpenAi.Moderation;

namespace Rystem.OpenAi
{
    internal sealed class OpenAiApi : OpenAiBase, IOpenAi
    {
        public IOpenAiModel Model { get; }
        public IOpenAiCompletion Completion { get; }
        public IOpenAiImage Image { get; }
        public IOpenAiEmbedding Embedding { get; }
        public IOpenAiFile File { get; }
        public IOpenAiModeration Moderation { get; }
        public IOpenAiAudio Audio { get; }
        public IOpenAiFineTune FineTune { get; }
        public IOpenAiChat Chat { get; }
        public IOpenAiEdit Edit { get; }
        public IOpenAiManagement Management { get; }

        public OpenAiApi(
            IHttpClientFactory httpClientFactory,
            IEnumerable<OpenAiConfiguration> configurations,
            IOpenAiUtility utility,
            IOpenAiCompletion completionApi,
            IOpenAiEmbedding embeddingApi,
            IOpenAiModel modelApi,
            IOpenAiFile fileApi,
            IOpenAiImage imageApi,
            IOpenAiModeration moderationApi,
            IOpenAiAudio audioApi,
            IOpenAiFineTune fineTuneApi,
            IOpenAiChat chatApi,
            IOpenAiEdit editApi,
            IOpenAiManagement managementApi) : base(httpClientFactory, configurations, utility)
        {
            SetAiBase(Completion = completionApi);
            SetAiBase(Embedding = embeddingApi);
            SetAiBase(Model = modelApi);
            SetAiBase(File = fileApi);
            SetAiBase(Image = imageApi);
            SetAiBase(Moderation = moderationApi);
            SetAiBase(Audio = audioApi);
            SetAiBase(FineTune = fineTuneApi);
            SetAiBase(Chat = chatApi);
            SetAiBase(Edit = editApi);
            SetAiBase(Management = managementApi);
        }
    }
}
