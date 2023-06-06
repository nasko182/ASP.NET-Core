namespace Forum.Data.Seeding
{
    using Forum.Data.Models.Models;

    public class PostSeeder
    {
        public ICollection<Post> GeneratePosts()
        {
            var posts = new List<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "Discover the secrets of mindfulness and unlock inner peace in just 10 minutes a day. 🌸\U0001f9d8‍♀️ #Mindfulness #InnerPeace"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My Second post",
                Content =
                    "Calling all bookworms! 📚🐛 Dive into the enchanting world of fantasy with our top 5 must-read novels. #BookLovers #FantasyBooks"
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content =
                    "Boost your productivity and conquer your goals with these 5 powerful morning habits. 🌞💪 #ProductivityTips #MorningRoutine"
            };
            posts.Add(currentPost);

            return posts;
        }
    }
}
