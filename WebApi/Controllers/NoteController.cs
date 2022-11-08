using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [SwaggerOperation(Summary = "Return all notes")]
        [HttpGet]
        public IActionResult Get()
        {
            var notes = _noteService.GetAllNotes();
            return Ok(notes);
        }

        [SwaggerOperation(Summary = "Return note with unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _noteService.GetNoteById(id);
            if(note ==null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [SwaggerOperation(Summary = "Create a new note")]
        [HttpPost]
        public IActionResult Create(CreateNoteDto newNote)
        {
            var note = _noteService.AddNewNote(newNote);
            return Created($"api/notes/{note.Id}", note);
        }

        [SwaggerOperation(Summary = "Update a note")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateNoteDto updatedNote)
        {
            _noteService.UpdateNote(id,updatedNote);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a note")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return NoContent();
        }
    }
}
