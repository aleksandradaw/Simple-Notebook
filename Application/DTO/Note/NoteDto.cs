namespace Application.DTO.Note
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Updated { get; set; }
        public CategoryDto Category { get; set; }

    }
}
