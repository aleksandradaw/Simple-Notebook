
namespace Domain.Entities
{
    public class Note 
    {
        public int Id { get; set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public NoteDetails Details { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }  

    }
}
