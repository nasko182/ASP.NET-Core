namespace Forum.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Forum.Data.Models.Models;

    using Seeding;
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>

    {
        private readonly PostSeeder _postSeeder;

        public PostEntityConfiguration()
        {
            this._postSeeder = new PostSeeder();
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this._postSeeder.GeneratePosts());
        }
    }
}
