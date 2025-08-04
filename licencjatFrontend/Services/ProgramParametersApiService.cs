using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace licencjatFrontend.Services
{
    public class ProgramParametersApiService
    {
        private readonly RestClient _client;

        public ProgramParametersApiService()
        {
            _client = new RestClient("https://localhost:44373/api/");
        }

        public async Task UpdateProgramParameterAsync(ProgramParameterDto parameterDto)
        {
            if (parameterDto == null || string.IsNullOrEmpty(parameterDto.Value))
            {
                throw new ArgumentException("Parametry nie mogą być puste");
            }

            var request = new RestRequest("ProgramParameters/Update", Method.Put);
            request.AddJsonBody(parameterDto);

            try
            {
                var response = await _client.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Brak autoryzacji do wykonania tej operacji.");
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new BadRequestException("Błędne dane w zapytaniu.");
                    }
                    else if (response.ErrorException != null)
                    {
                        throw new Exception("Błąd: " + response.ErrorMessage, response.ErrorException);
                    }
                    else
                    {
                        throw new Exception("Wystąpił nieznany błąd: " + response.StatusDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd połączenia z serwerem: " + ex.Message);
            }
        }

        public class ProgramParameterDto
        {
            public string Value { get; set; }
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
