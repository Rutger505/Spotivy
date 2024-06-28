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
        Console.WriteLine($"Paused {Title} by {Creator}");
    }

    public void Resume()
    {
        Console.WriteLine($"Resumed {Title} by {Creator}");
    }

    public void Skip()
    {
        Console.WriteLine($"Skipped {Title} by {Creator}");
    }
}