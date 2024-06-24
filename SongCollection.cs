namespace Spotivy;

public class SongCollection(string title, string creator, List<Song> songs)
    : IPlayable
{
    public List<Song> Songs { get; } = songs;
    public string Title { get; } = title;
    public string Creator { get; } = creator;
}