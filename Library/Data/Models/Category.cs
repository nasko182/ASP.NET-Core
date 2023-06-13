namespace Library.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

[Comment("Categories for the book")]
public class Category
{
    public Category()
    {
        this.Books = new HashSet<Book>();
    }
    [Comment("Primary key")]
    [Key]
    public int Id { get; set; }

    [Comment("Name of a category")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public IEnumerable<Book> Books { get; set; }
}

