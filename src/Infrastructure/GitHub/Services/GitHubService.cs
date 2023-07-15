
using System.Net.Http.Headers;
using Domain.Services;
using Domain.Shared.DTO;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GitHub.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IConfiguration _configuration;

        public GitHubService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<GitHubBranchDTO>> Branches()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", ".NET");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["GitHub:Token"]);

            var response = await client.GetAsync("https://api.github.com/repos/cesargraeff/rede-neural/branches");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar branch");

            var data = JsonConvert.DeserializeObject<List<GitHubBranchDTO>>(response.Content.ReadAsStringAsync().Result);

            if (data == null)
                throw new Exception("Erro ao converter dados");

            return data;
        }

        public async Task<List<GitHubCommitDTO>> Commits()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", ".NET");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["GitHub:Token"]);

            var response = await client.GetAsync("https://api.github.com/repos/cesargraeff/rede-neural/commits");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar commits");

            var data = JsonConvert.DeserializeObject<List<GitHubCommitDTO>>(response.Content.ReadAsStringAsync().Result);

            if (data == null)
                throw new Exception("Erro ao converter dados");

            return data;
        }

        public async Task<List<GitHubDeveloperDTO>> Developers()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", ".NET");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["GitHub:Token"]);

            var response = await client.GetAsync("https://api.github.com/repos/cesargraeff/rede-neural/collaborators");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar developers");

            var data = JsonConvert.DeserializeObject<List<GitHubDeveloperDTO>>(response.Content.ReadAsStringAsync().Result);

            if (data == null)
                throw new Exception("Erro ao converter developers");

            return data;
        }
    }
}