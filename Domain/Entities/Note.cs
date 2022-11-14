using System.Reflection.Metadata;

namespace Domain.Entities
{
    public class Note 
    {
        public int Id { get; set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }

        public Note()
        {

        }

    }
}
