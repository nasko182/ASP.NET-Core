using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Data.Models;

namespace TaskBoard.Data.Configurations
{
    internal class BoardEntityConfigurations : IEntityTypeConfiguration<Board>

    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = this.GenerateBoards();

            builder.HasData(boards);
        }

        private ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new HashSet<Board>()
            {
                 new Board()
                 {
                    Id = 1,
                    Name = "Open"
                 },
                 new Board()
                 {
                    Id = 2,
                    Name = "In Progress"
                 },
                 new Board()
                 {
                    Id = 3,
                    Name = "Done"
                 }

            };

            return boards;
        }
    }
}
