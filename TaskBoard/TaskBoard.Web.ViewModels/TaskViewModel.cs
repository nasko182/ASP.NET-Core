namespace TaskBoard.Web.ViewModels
{
    public class TaskViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int BoardId { get; set; }

        public string BoardName { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        public string OwnerId { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

    }
}
