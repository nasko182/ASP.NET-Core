namespace TaskBoard.Web.ViewModels.Board
{
    public class AllBoardViewModel
    {
        public AllBoardViewModel()
        {
            this.Tasks = new HashSet<TaskViewModel>();
        }
        public string Name { get; set; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
