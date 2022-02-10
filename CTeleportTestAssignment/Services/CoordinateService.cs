using CTeleportTestAssignment.Contracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTeleportTestAssignment.Services
{
    public class CoordinateService : ICoordinateService
    {
        public async Task<CoordinateModel> GetPositionCoordinateByIATACode(string iATACode)
        {
            using var httpClient = new HttpClient() { BaseAddress = new Uri(Constants.BaseURL) };
            var response = await httpClient.GetAsync(iATACode);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AirportModel>(data);
            return result.Location;
        }
    }
}