using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licencjatFrontend.Services
{
    public class RankingApiService
    {
        private readonly RestClient _client;

        public RankingApiService()
        {
            var options = new RestClientOptions("https://localhost:44373/api/")
            {
                ThrowOnAnyError = true
            };

            _client = new RestClient(options, configureSerialization: s => s.UseSystemTextJson());
        }

        public async Task<RankingDto> GetRankingAsync(List<CriterionWeight> weights)
        {
            var request = new RestRequest("Ranking/GetRanking", Method.Post);
            request.AddJsonBody(weights);

            var response = await _client.ExecuteAsync<RankingDto>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            throw new Exception(response.ErrorMessage ?? "Unknown error occurred");
        }

        public class RankingDto
        {
            public List<HostelWithResult> HostelsWithResult { get; set; }
        }

        public class HostelWithResult
        {
            public decimal Result { get; set; }
            public Hostel Hostel { get; set; }
        }

        public class Hostel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class CriterionWeight
        {
            public int CriterionId { get; set; }
            public decimal Weight { get; set; }
        }
    }
}
