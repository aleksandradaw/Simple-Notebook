namespace Application.DTO.Note
{
    public class ListNotesDto
    {
        public IEnumerable<NoteDto> Notes { get;set; }
        public int Count { get; set; }
    }
}
