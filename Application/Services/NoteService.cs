using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class NoteService : INoteService
    {

        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper; 

        }
        public IEnumerable<NoteDto> GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return _mapper.Map<IEnumerable<NoteDto>>(notes);
        }
        public NoteDto GetNoteById(int id)
        {
            var note = _noteRepository.GetById(id);
            return _mapper.Map<NoteDto>(note);

        }
        public NoteDto AddNewNote(CreateNoteDto newNote)
        {
            if(string.IsNullOrEmpty(newNote.Title))
            {
                throw new Exception("Title is empty");
            }

            var note = _mapper.Map<Note>(newNote);
            _noteRepository.Add(note);
            return _mapper.Map<NoteDto>(note);
        }

        public void DeleteNote(int id)
        {
            var existingNote = _noteRepository.GetById(id);
            _noteRepository.Delete(existingNote);
        }

        public void UpdateNote(int id, UpdateNoteDto updateNote)
        {
            if (string.IsNullOrEmpty(updateNote.Title))
            {
                throw new Exception("Title is empty");
            }

            var oldNote = _noteRepository.GetById(id);
            var newNote = _mapper.Map(updateNote,oldNote);  
            _noteRepository.Update(newNote);
        }
    }
}
