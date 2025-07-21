using System;
//Track video title, author and length (seconds). Each video should store a list of comments 
//and a method to return a count of them.

public class Video
{
    private string _videoTitle;
    private string _author;
    private int _numOfComments;
    private int _seconds;
    private List<Comment> _commentList = new List<Comment>();
    List<Video> videos = new List<Video>();
    public Video(string videoTitle, string author, int seconds)
    {
        _videoTitle = videoTitle;
        _author = author;
        _seconds = seconds;

    }

    public void AddComment(Comment comment)
    {
        _commentList.Add(comment);
    }

    public int CountComments()
    {
        return _commentList.Count;
    }

    public string VideoTitle => _videoTitle;
    public string Author => _author;
    public int Length => _seconds;

    public List<Comment> CommentList => _commentList;


}
