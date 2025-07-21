using System;
//No user interaction. Submit a ss of the working program.

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("LooksMaxxing 101", "GioHernandez", 60);
        video1.AddComment(new Comment("John", "Great video! I learned a lot."));
        video1.AddComment(new Comment("Mary", "Lol"));
        video1.AddComment(new Comment("Steve", "Nice and simple."));
        videos.Add(video1);

        Video video2 = new Video("Ducks at the park are free! (What the government doesn't tell you)", "DuckLover", 120);
        video2.AddComment(new Comment("Anna", "I want one so bad!"));
        video2.AddComment(new Comment("Lucas", "whaaat!"));
        video2.AddComment(new Comment("Nina", "Don't know about this one"));
        videos.Add(video2);

        Video video3 = new Video("Goodbye... (for now)", "Willyrex", 180);
        video3.AddComment(new Comment("Eliza", "Noooooo"));
        video3.AddComment(new Comment("Tom", "dead channel"));
        video3.AddComment(new Comment("Ruth", "so sad"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.VideoTitle}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.CountComments()}");

            foreach (Comment comment in video.CommentList)
            {
                Console.WriteLine($"  {comment.Commenter}: {comment.Text}");
            }

            Console.WriteLine();


        }
    }
}
