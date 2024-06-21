namespace Spotivy;

public class Song(string title, string creator, string genre) : IPlayable
{
    public string Title { get; } = title;
    public string Creator { get; } = creator;
    public string Genre { get; } = genre;

    public void Play()
    {
        Console.WriteLine($"Playing {Title} by {Creator}");
    }

    public void Pause()
    {
        throw new NotImplementedException();
    }

    public void Resume()
    {
        throw new NotImplementedException();
    }

    public void Skip()
    {
        throw new NotImplementedException();
    }

    public void Repeat(bool state)
    {
        throw new NotImplementedException();
    }
}