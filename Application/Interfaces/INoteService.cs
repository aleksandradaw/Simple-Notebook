namespace Application.Interfaces
{
    public interface INoteService
    {
        ListNotesDto GetAllNotes();
        NoteDto GetNoteById(int id);
        NoteDto AddNewNote(CreateNoteDto newNote);
        void UpdateNote(int id, UpdateNoteDto updateNote);
        void DeleteNote(int id);
        ListNotesDto SearchByKeyword(string keyword);
        
    }
}
