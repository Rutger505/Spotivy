namespace Spotivy;

public class SongCollection(string title, string creator, string genre, List<Song> songs)
    : IPlayable
{
    public List<Song> Songs { get; } = songs;
    public string Title { get; } = title;
    public string Creator { get; } = creator;
    public string Genre { get; } = genre;
}