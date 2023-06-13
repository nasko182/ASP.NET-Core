namespace Library.Services;

using Microsoft.EntityFrameworkCore;

using Library.Data.Models;
using Interfaces;
using Data;
using Models;

public class BookService : IBookService
{
    private readonly LibraryDbContext _dbContext;

    public BookService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BookForAllViewModel>> GetBooksForAllAsync()
    {
        return await _dbContext
            .Books
            .Select(b => new BookForAllViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Category = b.Category.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<BookForMineViewModel>> GetBooksForMineAsync(string userId)
    {
        return await _dbContext
            .IdentityUserBooks
            .Where(iu => iu.CollectorId == userId)
            .Select(b => new BookForMineViewModel()
            {
                Id = b.BookId,
                Author = b.Book.Author,
                Category = b.Book.Category.Name,
                Description = b.Book.Description,
                ImageUrl = b.Book.ImageUrl,
                Title = b.Book.Title,
            })
            .ToListAsync();
    }

    public async Task AddBookToMineCollectionAsync(string userId, int bookId)
    {
        bool isBookAdded = await _dbContext
            .IdentityUserBooks
            .AnyAsync(ub => ub.CollectorId == userId
                       && ub.BookId == bookId);

        if (!isBookAdded)
        {
            var userBook = new IdentityUserBook()
            {
                BookId = bookId,
                CollectorId = userId
            };

            await _dbContext.IdentityUserBooks.AddAsync(userBook);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveBookFromCollectionAsync(string userId, int bookId)
    {
        bool isBookAdded = await _dbContext
            .IdentityUserBooks
            .AnyAsync(ub => ub.CollectorId == userId
                            && ub.BookId == bookId);

        if (isBookAdded)
        {
            var userBook = new IdentityUserBook()
            {
                BookId = bookId,
                CollectorId = userId
            };

            _dbContext.IdentityUserBooks.Remove(userBook);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
    {
        return await _dbContext
            .Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<BookForAddViewModel?> GetBookByIdAsync(int id)
    {
        return await _dbContext
            .Books
            .Where(b => b.Id == id)
            .Select(b=>new BookForAddViewModel()
            {
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Url = b.ImageUrl,
                Rating = b.Rating,
                CategoryId = b.CategoryId
            })
            .FirstOrDefaultAsync();
    }

    public async Task AddBookAllCollectionAsync(BookForAddViewModel book)
    {
        await _dbContext.AddAsync(new Book()
        {
            Author = book.Author,
            CategoryId = book.CategoryId,
            Description = book.Description,
            ImageUrl = book.Url,
            Rating = book.Rating,
            Title = book.Title
        });

        await _dbContext.SaveChangesAsync();
    }

    public async Task EditBookAllCollectionAsync(BookForAddViewModel book, int id)
    {
        var book1 = await _dbContext.Books.FindAsync(id);

        if (book1!=null)
        {
            book1.Title=book.Title;
            book1.Author=book.Author;
            book1.Description=book.Description;
            book1.CategoryId=book.CategoryId;
            book1.Rating=book.Rating;
            book1.ImageUrl = book.Url;
        }

        await _dbContext.SaveChangesAsync();
    }
}