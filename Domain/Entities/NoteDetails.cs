namespace Domain.Entities
{
    public class NoteDetails
    {
        public int Id { get; set; }
        public DateTime Created { get;set; }
        public DateTime Updated { get; set; }
        public int NoteId { get; set; } 
        public Note Note { get; set; }  

    }
}
