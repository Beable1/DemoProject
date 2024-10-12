using CoreLayer.DTOs;
using DemoProject.Areas.Admin.Models;
using EntityLayer.DTOs;

namespace DemoProject.Areas.Admin.Services
{
    public class CategoryApiService
    {

        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category2>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Category2>>("statistic/GetCategoriesStatistics");

            return response;
        }
    }
}
