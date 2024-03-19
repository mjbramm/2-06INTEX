namespace Mission11_Brammer.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
