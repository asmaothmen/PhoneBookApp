using PhoneBookApi.DTOs;

namespace PhoneBookApi.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int id);
        Task AddContactAsync(ContactDTO dto);
        Task UpdateContactAsync(int id, ContactDTO dto);
        Task DeleteContactAsync(int id);
    }
}
