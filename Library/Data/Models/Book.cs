namespace Library.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;


[Comment("This is a book from a library")]
public class Book
{
    public Book()
    {
        this.UserBooks = new HashSet<IdentityUserBook>();
    }

    [Key]
    [Comment("Book ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Comment("Title of the book")]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Comment("Author of the book")]
    public string Author { get; set; } = null!;

    [Required]
    [MaxLength(5000)]
    [Comment("Description of the book")]
    public string Description { get; set; } = null!;

    [Required]
    [Comment("Image URL of the book")]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [Precision(18,2)]
    [Comment("Rating of the book")]
    public decimal Rating { get; set; }

    [Required]
    [Comment("Category of the book")]
    public int CategoryId { get; set; }

    [Required]
    [Comment("Category of the book")]
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public IEnumerable<IdentityUserBook> UserBooks { get; set; }
}


