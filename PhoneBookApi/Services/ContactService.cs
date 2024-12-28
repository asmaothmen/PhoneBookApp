using AutoMapper;
using PhoneBookApi.DTOs;
using PhoneBookApi.Models;
using PhoneBookApi.Repositories;

namespace PhoneBookApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
        }
        public async Task<ContactDTO> GetContactByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task AddContactAsync(ContactDTO dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            await _repository.AddAsync(contact);
        }
        public async Task UpdateContactAsync(int id, ContactDTO dto)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact != null)
            {
                _mapper.Map(dto, contact);
                await _repository.UpdateAsync(contact);
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
