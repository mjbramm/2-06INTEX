namespace Mission11_Brammer.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
