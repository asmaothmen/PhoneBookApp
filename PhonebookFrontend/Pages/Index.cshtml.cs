using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookFrontend.Models;
using System.Net.Http;

namespace PhonebookFrontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;

    public IndexModel(HttpClient httpClient, ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public IEnumerable<Contact> Contacts { get; private set; }

    public string SearchTerm { get; set; }

    public async Task OnGetAsync(string searchTerm)
    {
        SearchTerm = searchTerm;

        if (string.IsNullOrWhiteSpace(SearchTerm))
        {
            Contacts = await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>("api/contacts");
        }
        else
        {
            Contacts = await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/contacts/search?term={SearchTerm}");
        }
    }
    public async Task<IActionResult> OnPostDeleteAsync(int Id)
    {
        var response = await _httpClient.DeleteAsync($"api/contacts/{Id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Index");
        }
        return Page();
    }
}
