using Microsoft.AspNetCore.Mvc;
using Mission11_Brammer.Models;
using Mission11_Brammer.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Brammer.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var blah = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()

                }
            };

            return View(blah);
        }
    }
}
