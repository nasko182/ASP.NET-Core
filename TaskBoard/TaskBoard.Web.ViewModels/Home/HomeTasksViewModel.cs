namespace TaskBoard.Web.ViewModels.Home
{
    public class HomeTasksViewModel
    {
        public HomeTasksViewModel()
        {
            this.BoardsWithTasksCount = new List<HomeBoardViewModel>();
        }
        public int TotalCount { get; set; }

        public IEnumerable<HomeBoardViewModel> BoardsWithTasksCount { get; set; }

    }
}
