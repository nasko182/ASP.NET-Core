namespace Library.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


public class IdentityUserBook
{
    [Comment("Collector Id")]
    public string CollectorId { get; set; } = null!;

    [Comment("Collector")]
    [ForeignKey(nameof(CollectorId))]
    public IdentityUser Collector { get; set; } = null!;

    [Comment("Book id")]
    public int BookId { get; set; }

    [Comment("Book")]
    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; } = null!;
}

