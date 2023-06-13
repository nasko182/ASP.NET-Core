namespace Library.Services.Interfaces;

using Models;

public interface IBookService
{
    Task<IEnumerable<BookForAllViewModel>> GetBooksForAllAsync();

    Task<IEnumerable<BookForMineViewModel>> GetBooksForMineAsync(string userId);

    Task AddBookToMineCollectionAsync(string userId, int bookId);

    Task RemoveBookFromCollectionAsync(string userId, int bookId);

    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

    Task<BookForAddViewModel?> GetBookByIdAsync(int id);

    Task AddBookAllCollectionAsync(BookForAddViewModel book);

    Task EditBookAllCollectionAsync(BookForAddViewModel book,int id);

}