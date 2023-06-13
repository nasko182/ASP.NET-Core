namespace Library.Models;

using System.ComponentModel.DataAnnotations;

public class BookForAddViewModel
{
    public BookForAddViewModel()
    {
        this.Categories = new HashSet<CategoryViewModel>();
    }


    [Required]
    [StringLength(50,MinimumLength = 10)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(5000, MinimumLength = 5)]
    public string Description { get; set; } = null!;

    [Required]
    public string Url { get; set; } = null!;

    [Required]
    [Range(0.00d, 10.00d)]
    public decimal Rating { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; }
}