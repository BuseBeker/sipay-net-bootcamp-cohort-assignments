using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public APIResponse(T data)
        {
            Data = data;
            Success = true;
            Message = string.Empty;
        }
    }

    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private List<Book> list;

        public BookController()
        {
            list = new List<Book>
            {
                new Book { Id = 1, Name = "Kurutulmuş Felsefe Bahçesi", Writer = "Salah Birsel", Type = "Deneme", Price = 47 },
                new Book { Id = 2, Name = "Bir İz Bırak", Writer = "Veronica Roth", Type = "Fantastik", Price = 108 },
                new Book { Id = 3, Name = "Beynine Format At", Writer = "John Verdon", Type = "Kişisel Gelişim", Price = 82 },
                new Book { Id = 4, Name = "Gözlerini Sımsıkı Kapat", Writer = "M. Barış Muslu", Type = "Polisiye-Macera", Price = 97 },
                new Book { Id = 5, Name = "Nutuk", Writer = "Mustafa Kemal Atatürk", Type = "Tarih", Price = 6 }
            };
        }

        [HttpGet]
        public ActionResult<APIResponse<List<Book>>> Get()
        {
            return new APIResponse<List<Book>>(list);
        }

        [HttpGet("{id}")]
        public ActionResult<APIResponse<Book>> Get(int id)
        {
            var book = list.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(new APIResponse<Book>(null)
                {
                    Success = false,
                    Message = "Book not found."
                });
            }

            return new APIResponse<Book>(book);
        }

        [HttpGet("list")]
        public ActionResult<APIResponse<List<Book>>> Get([FromQuery] string name)
        {
            var filteredList = list;
            if (!string.IsNullOrWhiteSpace(name))
            {
                filteredList = filteredList.Where(x => x.Name.Contains(name)).ToList();
            }

            return new APIResponse<List<Book>>(filteredList);
        }

        [HttpPost]
        public ActionResult<APIResponse<List<Book>>> Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Invalid book data."
                });
            }

            book.Id = list.Max(x => x.Id) + 1;
            list.Add(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, new APIResponse<List<Book>>(list));
        }

        [HttpPut("{id}")]
        public ActionResult<APIResponse<List<Book>>> Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Invalid book data."
                });
            }

            var existingBook = list.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return NotFound(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Book not found."
                });
            }

            existingBook.Name = book.Name;
            existingBook.Writer = book.Writer;
            existingBook.Type = book.Type;
            existingBook.Price = book.Price;

            return new APIResponse<List<Book>>(list);
        }

        [HttpPatch("{id}")]
        public ActionResult<APIResponse<List<Book>>> Patch(int id, [FromBody] JsonPatchDocument<Book> patchDocument)
        {
            var existingBook = list.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return NotFound(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Book not found."
                });
            }

            patchDocument.ApplyTo(existingBook, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Invalid patch data."
                });
            }

            return new APIResponse<List<Book>>(list);
        }

        [HttpDelete("{id}")]
        public ActionResult<APIResponse<List<Book>>> Delete(int id)
        {
            var existingBook = list.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return NotFound(new APIResponse<List<Book>>(null)
                {
                    Success = false,
                    Message = "Book not found."
                });
            }

            list.Remove(existingBook);

            return new APIResponse<List<Book>>(list);
        }
    }
}

