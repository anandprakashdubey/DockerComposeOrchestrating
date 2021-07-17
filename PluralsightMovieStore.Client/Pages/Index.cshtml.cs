using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PluralsightMovieStore.Client.Pages
{
    public class IndexModel : PageModel
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<IndexModel> _logger;
        public string[] Names { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("PricingApiClient");
        }       
     

        public async Task OnGet()
        {
            var response = await _httpClient.GetAsync("/api/names");
            var content = await response.Content.ReadAsStringAsync();
            Names = JsonSerializer.Deserialize<string[]>(content);
        }                 
    }
}
