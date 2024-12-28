using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.DTOs;
using PhoneBookApi.Models;
using PhoneBookApi.Services;
using System.Net;

    namespace PhoneBookApi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ContactsController : ControllerBase
        {
            private readonly IContactService _service;

            public ContactsController(IContactService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var contacts = await _service.GetAllContactsAsync();
                return Ok(contacts);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var contact = await _service.GetContactByIdAsync(id);
                return contact != null ? Ok(contact) : NotFound();
            }

            [HttpPost]
            public async Task<IActionResult> Add(ContactDTO dto)
            {
                await _service.AddContactAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto }, dto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, ContactDTO dto)
            {
                await _service.UpdateContactAsync(id, dto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _service.DeleteContactAsync(id);
                return NoContent();
            }
        }
    }


