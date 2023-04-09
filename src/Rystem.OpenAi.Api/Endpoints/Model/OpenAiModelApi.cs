﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Rystem.OpenAi
{
    internal sealed class OpenAiModelApi : OpenAiBase, IOpenAiModelApi
    {
        private readonly bool _forced;
        public OpenAiModelApi(IHttpClientFactory httpClientFactory, IEnumerable<OpenAiConfiguration> configurations)
            : base(httpClientFactory, configurations)
        {
            _forced = false;
        }
        public ValueTask<Model> RetrieveAsync(string id, CancellationToken cancellationToken = default)
            => _client.GetAsync<Model>($"{_configuration.GetUri(OpenAiType.Model, string.Empty, _forced)}/{id}", _configuration, cancellationToken);
        public async Task<List<Model>> ListAsync(CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync<JsonHelperRoot>(_configuration.GetUri(OpenAiType.Model, string.Empty, _forced), _configuration, cancellationToken);
            return response.Data!;
        }
        private sealed class JsonHelperRoot : ApiBaseResponse
        {
            [JsonPropertyName("data")]
            public List<Model>? Data { get; set; }
        }
    }
}
