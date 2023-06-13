namespace Library.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using Models;

public class BookController : BaseController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        this._bookService = bookService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<BookForAllViewModel> allBooks = await _bookService.GetBooksForAllAsync();

        return View(allBooks);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var book = new BookForAddViewModel()
        {
            Categories = await _bookService.GetAllCategoriesAsync()
        };
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookForAddViewModel book)
    {
        try
        {
            await _bookService.AddBookAllCollectionAsync(book);
        }
        catch (Exception)
        {
            return View(book);
        }

        return RedirectToAction("All");
    }

    public async Task<IActionResult> Mine()
    {
        var userId = User.Claims.First().Value;
        IEnumerable<BookForMineViewModel> mineBooks = await _bookService.GetBooksForMineAsync(userId);

        return View(mineBooks);
    }

    public async Task<IActionResult> AddToCollection(int id)
    {
        var userId = GetUserId();

        await _bookService.AddBookToMineCollectionAsync(userId, id);

        return RedirectToAction("All");
    }

    public async Task<IActionResult> RemoveFromCollection(int id)
    {
        var userId = GetUserId();

        await _bookService.RemoveBookFromCollectionAsync(userId, id);

        return RedirectToAction("Mine");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book != null)
        {
            book.Categories = await _bookService.GetAllCategoriesAsync();
            return View(book);
        }

        return RedirectToAction("All");

    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,BookForAddViewModel book)
    {
        try
        {
            await _bookService.EditBookAllCollectionAsync(book, id);
        }
        catch (Exception)
        {
            return View(book);
        }

        return RedirectToAction("All");
    }
}