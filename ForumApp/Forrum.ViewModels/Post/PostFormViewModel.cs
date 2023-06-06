namespace Forum.ViewModels.Post;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.EntityValidations.Post;

public class PostFormViewModel
{
    [Required]
    [MaxLength(TitleMaxLength)]
    [MinLength(TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    [MinLength(ContentMinLength)]
    public string Content { get; set; } = null!;
}

