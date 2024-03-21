using Microsoft.AspNetCore.Mvc;
using Mission11_Brammer.Models;

namespace Mission11_Brammer.Components
{
    public class BookCategoriesViewComponent : ViewComponent
    {

        private IBookRepository _bookRepo;
        //Constructor 
        public BookCategoriesViewComponent(IBookRepository temp) 
        { 
            _bookRepo = temp;

        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedBookCategory = RouteData?.Values["bookCategory"];

            var bookCategories = _bookRepo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(bookCategories);

        }
    }
}
