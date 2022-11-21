namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly MyNotesContext _context;
        public NoteRepository(MyNotesContext context)
        {
            _context = context; 
        }
        public IQueryable<Note> GetAll()
        {
            return _context.Notes
                .Include(x => x.Details)
                .Include(y => y.Category);
        }

        public Note GetById(int id)
        { 
            return _context.Notes
                .Include(x=>x.Details)
                .Include(y=>y.Category)
                .SingleOrDefault(x => x.Id == id);
        }
        public Note Add(Note note)
        {
           _context.Notes.Add(note);
           _context.SaveChanges();
            return note;

        }

        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
            
        }
    }
}
