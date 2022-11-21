namespace Application.Services
{
    public class NoteService : INoteService
    {

        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public NoteService(INoteRepository noteRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;

        }
        public ListNotesDto GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return _mapper.Map<ListNotesDto>(notes);
        }

        public ListNotesDto SearchByKeyword(string keyword) 
        {
            string keyword2 = keyword.ToLowerInvariant();
            var notes = _noteRepository.GetAll()
                .Where(x => x.Title.ToLower().Contains(keyword2) || x.Content.ToLower().Contains(keyword2));
            return _mapper.Map<ListNotesDto>(notes);
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

            var category = _categoryRepository.GetById(newNote.CategoryId);

            if(category == null)
            {
                throw new Exception("Category does not exist!");
            }

            var note = _mapper.Map<Note>(newNote);
            note.Details = new NoteDetails()
            {
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

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

            newNote.Details.Updated = DateTime.UtcNow;

            _noteRepository.Update(newNote);
        }
    }
}
