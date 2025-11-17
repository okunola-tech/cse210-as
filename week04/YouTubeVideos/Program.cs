using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video v1 = new Video("Exploring the Ocean", "BlueWorld", 540);
        Video v2 = new Video("How to Cook Pasta", "ChefMario", 330);
        Video v3 = new Video("Top 10 Coding Tips", "DevMaster", 720);

        // Add comments for Video 1
        v1.AddComment(new Comment("Anna", "Amazing underwater footage!"));
        v1.AddComment(new Comment("Lucas", "I love marine life."));
        v1.AddComment(new Comment("Mia", "The ending was beautiful."));

        // Add comments for Video 2
        v2.AddComment(new Comment("Jamie", "This actually helped me!"));
        v2.AddComment(new Comment("Chris", "My pasta finally tastes good."));
        v2.AddComment(new Comment("Riley", "Simple and clear instructions."));

        // Add comments for Video 3
        v3.AddComment(new Comment("Henry", "These tips improved my code!"));
        v3.AddComment(new Comment("Sarah", "Love this channel."));
        v3.AddComment(new Comment("Tom", "Very well explained."));

        // Put videos in a list
        List<Video> videos = new List<Video> { v1, v2, v3 };

        // Display each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
