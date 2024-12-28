using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookFrontend.Models;

namespace PhonebookFrontend.Pages
{
    public class UpsertModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public Contact Contact { get; set; }

        public UpsertModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGetAsync(int? id)
        {
            if (id > 0)
            {
                Contact = await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
            }
            else
            {
                Contact = new Contact();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Contact.Id > 0)
            {
                await _httpClient.PutAsJsonAsync($"api/contacts/{Contact.Id}", Contact);
            }
            else
            {
                await _httpClient.PostAsJsonAsync("api/contacts", Contact);
            }
          

            return RedirectToPage("Index");
        }
    }
}

