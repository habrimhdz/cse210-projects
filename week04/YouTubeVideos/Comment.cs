using System;
//This should track the name of the user who commented and the comment's text itself.
public class Comment
{
    private string _commenter;
    private string _comment;


    public Comment(string commenter, string comment)
    {
        _commenter = commenter;
        _comment = comment;
    }

    public string Commenter => _commenter;
    public string Text => _comment;

}