using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static licencjatFrontend.ViewModels.CriterionViewModel;

namespace licencjatFrontend.Services
{
    public class CriterionApiService
    {
        private readonly RestClient _client;

        public CriterionApiService()
        {
            _client = new RestClient("https://localhost:44373/api/");
        }

        public async Task<List<Criterion>> GetAllCriteriaAsync()
        {
            var request = new RestRequest("Ranking/GetCriteriaForRanking", Method.Get);
            var response = await _client.ExecuteAsync<List<Criterion>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            throw new Exception(response.ErrorMessage ?? "Unknown error");
        }

        public async Task AddCriterionAsync(string criterion)
        {
            var request = new RestRequest("api/criterion/add", Method.Post);
            request.AddJsonBody(new { Name = criterion });
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception(response.ErrorMessage ?? "Unknown error");
            }
        }

        public async Task DeleteCriterionAsync(int id)
        {
            var request = new RestRequest($"api/criterion/delete/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception(response.ErrorMessage ?? "Unknown error");
            }
        }
    }
}
